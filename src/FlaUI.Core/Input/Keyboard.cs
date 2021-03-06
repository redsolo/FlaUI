﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core.Input
{
    /// <summary>
    /// Implementation for the keyboard
    /// </summary>
    public static class Keyboard
    {
        public static void Type(char character)
        {
            var code = User32.VkKeyScan(character);
            // Check if the char is unicode or no virtual key could be found
            if (character > 0xFE || code == -1)
            {
                // It seems to be unicode
                SendInput(character, true, false, false, true);
                SendInput(character, false, false, false, true);
            }
            else
            {
                // Get the high-order and low-order byte from the code
                var high = (byte)(code >> 8);
                var low = (byte)(code & 0xff);

                // Check if there are any modifiers
                var modifiers = new List<VirtualKeyShort>();
                if (HasScanModifier(high, VkKeyScanModifiers.SHIFT))
                {
                    modifiers.Add(VirtualKeyShort.SHIFT);
                }
                if (HasScanModifier(high, VkKeyScanModifiers.CONTROL))
                {
                    modifiers.Add(VirtualKeyShort.CONTROL);
                }
                if (HasScanModifier(high, VkKeyScanModifiers.ALT))
                {
                    modifiers.Add(VirtualKeyShort.ALT);
                }
                // Press the modifiers
                foreach (var mod in modifiers)
                {
                    PressVirtualKeyCode(mod);
                }
                // Type the effective key
                SendInput(low, true, false, false, false);
                SendInput(low, false, false, false, false);
                // Release the modifiers
                foreach (var mod in Enumerable.Reverse(modifiers))
                {
                    ReleaseVirtualKeyCode(mod);
                }
            }
        }

        public static void TypeScanCode(ushort scanCode, bool isExtendedKey)
        {
            PressScanCode(scanCode, isExtendedKey);
            ReleaseScanCode(scanCode, isExtendedKey);
        }

        public static void TypeVirtualKeyCode(ushort virtualKeyCode)
        {
            PressVirtualKeyCode(virtualKeyCode);
            ReleaseVirtualKeyCode(virtualKeyCode);
        }

        public static void TypeVirtualKeyCode(VirtualKeyShort virtualKey)
        {
            TypeVirtualKeyCode((ushort)virtualKey);
        }

        public static void PressScanCode(ushort scanCode, bool isExtendedKey)
        {
            SendInput(scanCode, true, true, isExtendedKey, false);
        }

        public static void PressVirtualKeyCode(ushort virtualKeyCode)
        {
            SendInput(virtualKeyCode, true, false, false, false);
        }

        public static void PressVirtualKeyCode(VirtualKeyShort virtualKey)
        {
            PressVirtualKeyCode((ushort)virtualKey);
        }

        public static void ReleaseScanCode(ushort scanCode, bool isExtendedKey)
        {
            SendInput(scanCode, false, true, isExtendedKey, false);
        }

        public static void ReleaseVirtualKeyCode(ushort virtualKeyCode)
        {
            SendInput(virtualKeyCode, false, false, false, false);
        }

        public static void ReleaseVirtualKeyCode(VirtualKeyShort virtualKey)
        {
            ReleaseVirtualKeyCode((ushort)virtualKey);
        }

        public static void Write(string textToWrite)
        {
            foreach (var c in textToWrite)
            {
                Type(c);
            }
        }

        /// <summary>
        /// Checks if a given byte has a specific VkKeyScan-modifier set
        /// </summary>
        private static bool HasScanModifier(byte b, VkKeyScanModifiers modifierToTest)
        {
            return (VkKeyScanModifiers)(b & (byte)modifierToTest) == modifierToTest;
        }

        /// <summary>
        /// Effectively sends the keyboard input command
        /// </summary>
        /// <param name="keyCode">The key code to send. Can be the scan code or the virtual key code</param>
        /// <param name="isKeyDown">Flag if the key should be pressed or released</param>
        /// <param name="isScanCode">Flag if the code is the scan code or the virtual key code</param>
        /// <param name="isExtended">Flag if the key is an extended key</param>
        /// <param name="isUnicode">Flag if the key is unicode</param>
        private static void SendInput(ushort keyCode, bool isKeyDown, bool isScanCode, bool isExtended, bool isUnicode)
        {
            // Prepare the basic object
            var keyboardInput = new KEYBDINPUT
            {
                time = 0,
                dwExtraInfo = User32.GetMessageExtraInfo()
            };

            // Add the "key-up" flag if needed. By default it is "key-down"
            if (!isKeyDown)
            {
                keyboardInput.dwFlags |= KeyEventFlags.KEYEVENTF_KEYUP;
            }

            if (isScanCode)
            {
                keyboardInput.wScan = keyCode;
                keyboardInput.dwFlags |= KeyEventFlags.KEYEVENTF_SCANCODE;
                // Add the extended flag if the flag is set or the keycode is prefixed with the byte 0xE0
                // See https://msdn.microsoft.com/en-us/library/windows/desktop/ms646267(v=vs.85).aspx
                if (isExtended || (keyCode & 0xFF00) == 0xE0)
                {
                    keyboardInput.dwFlags |= KeyEventFlags.KEYEVENTF_EXTENDEDKEY;
                }
            }
            else if (isUnicode)
            {
                keyboardInput.dwFlags |= KeyEventFlags.KEYEVENTF_UNICODE;
                keyboardInput.wScan = keyCode;
            }
            else
            {
                keyboardInput.wVk = keyCode;
            }

            // Build the input object
            var input = INPUT.KeyboardInput(keyboardInput);
            // Send the command
            if (User32.SendInput(1, new[] { input }, INPUT.Size) == 0)
            {
                // An error occured
                var errorCode = Marshal.GetLastWin32Error();
            }
        }
    }
}

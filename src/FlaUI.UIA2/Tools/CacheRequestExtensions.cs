﻿using FlaUI.Core;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Tools
{
    public static class CacheRequestExtensions
    {
        public static UIA.CacheRequest ToNative(this ICacheRequest cacheRequest)
        {
            return ((UIA2CacheRequest)cacheRequest)?.NativeCacheRequest;
        }
    }
}

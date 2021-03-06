﻿using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.UIA3.Patterns;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3
{
    public class UIA3PatternFactory : IPatternFactory
    {
        public UIA3BasicAutomationElement BasicAutomationElement { get; }

        internal UIA3PatternFactory(UIA3BasicAutomationElement basicAutomationElement)
        {
            BasicAutomationElement = basicAutomationElement;
        }

        public IAnnotationPattern GetAnnotationPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationAnnotationPattern>(AnnotationPattern.Pattern);
            return nativePattern == null ? null : new AnnotationPattern(BasicAutomationElement, nativePattern);
        }

        public IDockPattern GetDockPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationDockPattern>(DockPattern.Pattern);
            return nativePattern == null ? null : new DockPattern(BasicAutomationElement, nativePattern);
        }

        public IDragPattern GetDragPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationDragPattern>(DragPattern.Pattern);
            return nativePattern == null ? null : new DragPattern(BasicAutomationElement, nativePattern);
        }

        public IDropTargetPattern GetDropTargetPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationDropTargetPattern>(DropTargetPattern.Pattern);
            return nativePattern == null ? null : new DropTargetPattern(BasicAutomationElement, nativePattern);
        }

        public IExpandCollapsePattern GetExpandCollapsePattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationExpandCollapsePattern>(ExpandCollapsePattern.Pattern);
            return nativePattern == null ? null : new ExpandCollapsePattern(BasicAutomationElement, nativePattern);
        }

        public IGridItemPattern GetGridItemPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationGridItemPattern>(GridItemPattern.Pattern);
            return nativePattern == null ? null : new GridItemPattern(BasicAutomationElement, nativePattern);
        }

        public IGridPattern GetGridPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationGridPattern>(GridPattern.Pattern);
            return nativePattern == null ? null : new GridPattern(BasicAutomationElement, nativePattern);
        }

        public IInvokePattern GetInvokePattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationInvokePattern>(InvokePattern.Pattern);
            return nativePattern == null ? null : new InvokePattern(BasicAutomationElement, nativePattern);
        }

        public IItemContainerPattern GetItemContainerPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationItemContainerPattern>(ItemContainerPattern.Pattern);
            return nativePattern == null ? null : new ItemContainerPattern(BasicAutomationElement, nativePattern);
        }

        public ILegacyIAccessiblePattern GetLegacyIAccessiblePattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationLegacyIAccessiblePattern>(LegacyIAccessiblePattern.Pattern);
            return nativePattern == null ? null : new LegacyIAccessiblePattern(BasicAutomationElement, nativePattern);
        }

        public IMultipleViewPattern GetMultipleViewPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationMultipleViewPattern>(MultipleViewPattern.Pattern);
            return nativePattern == null ? null : new MultipleViewPattern(BasicAutomationElement, nativePattern);
        }

        public IObjectModelPattern GetObjectModelPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationObjectModelPattern>(ObjectModelPattern.Pattern);
            return nativePattern == null ? null : new ObjectModelPattern(BasicAutomationElement, nativePattern);
        }

        public IRangeValuePattern GetRangeValuePattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationRangeValuePattern>(RangeValuePattern.Pattern);
            return nativePattern == null ? null : new RangeValuePattern(BasicAutomationElement, nativePattern);
        }

        public IScrollItemPattern GetScrollItemPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationScrollItemPattern>(ScrollItemPattern.Pattern);
            return nativePattern == null ? null : new ScrollItemPattern(BasicAutomationElement, nativePattern);
        }

        public IScrollPattern GetScrollPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationScrollPattern>(ScrollPattern.Pattern);
            return nativePattern == null ? null : new ScrollPattern(BasicAutomationElement, nativePattern);
        }

        public ISelectionItemPattern GetSelectionItemPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationSelectionItemPattern>(SelectionItemPattern.Pattern);
            return nativePattern == null ? null : new SelectionItemPattern(BasicAutomationElement, nativePattern);
        }

        public ISelectionPattern GetSelectionPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationSelectionPattern>(SelectionPattern.Pattern);
            return nativePattern == null ? null : new SelectionPattern(BasicAutomationElement, nativePattern);
        }

        public ISpreadsheetItemPattern GetSpreadsheetItemPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationSpreadsheetItemPattern>(SpreadsheetItemPattern.Pattern);
            return nativePattern == null ? null : new SpreadsheetItemPattern(BasicAutomationElement, nativePattern);
        }

        public ISpreadsheetPattern GetSpreadsheetPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationSpreadsheetPattern>(SpreadsheetPattern.Pattern);
            return nativePattern == null ? null : new SpreadsheetPattern(BasicAutomationElement, nativePattern);
        }

        public IStylesPattern GetStylesPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationStylesPattern>(StylesPattern.Pattern);
            return nativePattern == null ? null : new StylesPattern(BasicAutomationElement, nativePattern);
        }

        public ISynchronizedInputPattern GetSynchronizedInputPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationSynchronizedInputPattern>(SynchronizedInputPattern.Pattern);
            return nativePattern == null ? null : new SynchronizedInputPattern(BasicAutomationElement, nativePattern);
        }

        public ITableItemPattern GetTableItemPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationTableItemPattern>(TableItemPattern.Pattern);
            return nativePattern == null ? null : new TableItemPattern(BasicAutomationElement, nativePattern);
        }

        public ITablePattern GetTablePattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationTablePattern>(TablePattern.Pattern);
            return nativePattern == null ? null : new TablePattern(BasicAutomationElement, nativePattern);
        }

        public ITextChildPattern GetTextChildPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationTextChildPattern>(TextChildPattern.Pattern);
            return nativePattern == null ? null : new TextChildPattern(BasicAutomationElement, nativePattern);
        }

        public ITextEditPattern GetTextEditPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationTextEditPattern>(TextEditPattern.Pattern);
            return nativePattern == null ? null : new TextEditPattern(BasicAutomationElement, nativePattern);
        }

        public IText2Pattern GetText2Pattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationTextPattern2>(Text2Pattern.Pattern);
            return nativePattern == null ? null : new Text2Pattern(BasicAutomationElement, nativePattern);
        }

        public ITextPattern GetTextPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationTextPattern>(TextPattern.Pattern);
            return nativePattern == null ? null : new TextPattern(BasicAutomationElement, nativePattern);
        }

        public ITogglePattern GetTogglePattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationTogglePattern>(TogglePattern.Pattern);
            return nativePattern == null ? null : new TogglePattern(BasicAutomationElement, nativePattern);
        }

        public ITransform2Pattern GetTransform2Pattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationTransformPattern2>(Transform2Pattern.Pattern);
            return nativePattern == null ? null : new Transform2Pattern(BasicAutomationElement, nativePattern);
        }

        public ITransformPattern GetTransformPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationTransformPattern>(TransformPattern.Pattern);
            return nativePattern == null ? null : new TransformPattern(BasicAutomationElement, nativePattern);
        }

        public IValuePattern GetValuePattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationValuePattern>(ValuePattern.Pattern);
            return nativePattern == null ? null : new ValuePattern(BasicAutomationElement, nativePattern);
        }

        public IVirtualizedItemPattern GetVirtualizedItemPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationVirtualizedItemPattern>(VirtualizedItemPattern.Pattern);
            return nativePattern == null ? null : new VirtualizedItemPattern(BasicAutomationElement, nativePattern);
        }

        public IWindowPattern GetWindowPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationWindowPattern>(WindowPattern.Pattern);
            return nativePattern == null ? null : new WindowPattern(BasicAutomationElement, nativePattern);
        }

        /// <summary>
        /// Generic method to get any native pattern and cast it to the desired type
        /// </summary>
        public T GetNativePatternAs<T>(PatternId pattern) where T : class
        {
            var nativePattern = BasicAutomationElement.NativeElement.GetCurrentPattern(pattern.Id);
            return (T)nativePattern;
        }
    }
}

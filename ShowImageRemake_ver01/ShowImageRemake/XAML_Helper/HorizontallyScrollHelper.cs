using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using System.Windows.Media;
using System.Windows;

using System.Windows.Input;

namespace ShowImageRemake.XAML_Helper
{
    internal class HorizontallyScrollHelper
    {
        public static readonly DependencyProperty ShiftWheelScrollsHorizontallyProperty = DependencyProperty.RegisterAttached(
        "ShiftWheelScrollsHorizontally",
        typeof(bool),
        typeof(HorizontallyScrollHelper),
        new PropertyMetadata(false, UseHorizontalScrollingChangedCallback));
        public static void SetShiftWheelScrollsHorizontally(UIElement element, bool value) => element.SetValue(ShiftWheelScrollsHorizontallyProperty, value);
        public static bool GetShiftWheelScrollsHorizontally(UIElement element) => (bool)element.GetValue(ShiftWheelScrollsHorizontallyProperty);


        private static void UseHorizontalScrollingChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as UIElement;


            if (element == null)
                throw new Exception("Attached property must be used with UIElement.");

            if ((bool)e.NewValue)
                element.PreviewMouseWheel += OnPreviewMouseWheel;
            else
                element.PreviewMouseWheel -= OnPreviewMouseWheel;
        }

        private static void OnPreviewMouseWheel(object sender, MouseWheelEventArgs args)
        {
            var scrollViewer = (ScrollViewer)sender;
            if (scrollViewer == null)
                return;

            if (Keyboard.Modifiers != MyDataContext.KeyboardShortcutDataContext.HorizontallyScrollShortcut)
                return;

            if (args.Delta < 0)
                scrollViewer.LineRight();
            else
                scrollViewer.LineLeft();

            //args.Handled = true;
        }
    }

}

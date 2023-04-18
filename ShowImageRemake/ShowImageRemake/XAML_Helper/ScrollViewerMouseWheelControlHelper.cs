
using System;
using System.Windows;
using System.Windows.Input;
namespace ShowImageRemake.XAML_Helper
{
    //這個類別可以為上下滾動軸增添修飾鍵控制
    internal class ScrollViewerMouseWheelControlHelper
    {
        public static readonly DependencyProperty IsChangeScrollViewerMouseWheelProperty = DependencyProperty.RegisterAttached(
   "IsChangeScrollViewerMouseWheel",
   typeof(bool),
   typeof(ScrollViewerMouseWheelControlHelper),
   new PropertyMetadata(false, IsChangeScrollViewerMouseWheelChanged));

        public static void SetIsChangeScrollViewerMouseWheel(DependencyObject element, bool value)
            => element.SetValue(IsChangeScrollViewerMouseWheelProperty, value);
        public static bool GetIsChangeScrollViewerMouseWheel(DependencyObject element)
            => (bool)element.GetValue(IsChangeScrollViewerMouseWheelProperty);

        private static void IsChangeScrollViewerMouseWheelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = d as UIElement;

            if (element == null)
                throw new Exception("Attached property must be used with UIElement.");




            if ((bool)e.NewValue == true)
                element.MouseWheel += UIElement_OnMouseWheel;
            else
                element.MouseWheel -= UIElement_OnMouseWheel;
        }

        private static void UIElement_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.Modifiers != MyDataContext.KeyboardShortcutDataContext.VerticallyScrollShortcut)
            {
                e.Handled = true;
                return;
            }


            //handler your zoomIn/Out here
        }

    }
}

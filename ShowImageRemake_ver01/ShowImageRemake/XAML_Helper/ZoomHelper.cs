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
    public static class ZoomHelper
    {
        public static readonly DependencyProperty IsEnableZoomProperty =
            DependencyProperty.RegisterAttached(
       "IsEnableZoom",
       typeof(bool),
       typeof(ZoomHelper),
       new PropertyMetadata(false, UseZoomCallback));

        public static void SetIsEnableZoom(UIElement element, bool value) =>
            element.SetValue(IsEnableZoomProperty, value);
        public static bool GetIsEnableZoom(UIElement element) =>
            (bool)element.GetValue(IsEnableZoomProperty);


        private static void UseZoomCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = d as FrameworkElement;
            //Image element = d.GetChildOfType<Image>();


            if (element == null)
                throw new Exception("Attached property must be used with UIElement.");

            var group = new TransformGroup();
            var st = new ScaleTransform();
            group.Children.Add(st);

            element.LayoutTransform = group;
            element.RenderTransformOrigin = new Point(0.0, 0.0);



            if ((bool)e.NewValue)
                element.PreviewMouseWheel += UIElement_Preview_MouseWheel;
            else
                element.PreviewMouseWheel -= UIElement_Preview_MouseWheel;
        }

        private static void UIElement_Preview_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Console.WriteLine("UIElement_Preview_MouseWheel");
            Console.WriteLine(Keyboard.Modifiers);
            if (Keyboard.Modifiers != MyDataContext.KeyboardShortcutDataContext.ZoomShortcut)//
                return;

            if(Keyboard.Modifiers == ModifierKeys.Alt)//alt is system key
            {
                if (MyDataContext.AltControlDataContext.mSystemKeyIsDown != true)//如果沒有按alt
                {
                    return;
                }
                // If it is the first scroll since it being down...
                //如果有滾動 則設定FocusedElement
                if (MyDataContext.AltControlDataContext.mHasScrolledWithSystemKeyDown == false)
                {
                    // Remember currently focused item
                    MyDataContext.AltControlDataContext.mLastFocusedControl = Keyboard.FocusedElement;
                }
                // And flag as scrolled with system key down
                //紀錄在按下system key時,有滾動
                MyDataContext.AltControlDataContext.mHasScrolledWithSystemKeyDown = true;
            }
            // Prevent scroll...
            e.Handled = true;

            // TODO: Zoom
            var st = GetScaleTransform(sender as FrameworkElement);
            if (!(e.Delta > 0) && (st.ScaleX < .21 || st.ScaleY < .21)) return;
            var zoom = e.Delta > 0 ? 0.2 : -0.2;
            st.ScaleX += zoom;
            st.ScaleY += zoom;
        }

        private static ScaleTransform GetScaleTransform(FrameworkElement element)
        {
            return (ScaleTransform)((TransformGroup)element.LayoutTransform).Children.First(tr => tr is ScaleTransform);
        }
    }
}

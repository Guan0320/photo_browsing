using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;  // For DependencyObject
using System.Windows.Controls; //For ScrollViewer and ScrollChangedEventArgs


namespace ShowImageRemake.XAML_Helper
{
    internal class ZoomByMousePositionHelper
    {


        public static bool GetIsEnableZoomByMousePosition(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsEnableZoomByMousePositionProperty);
        }

        public static void SetIsEnableZoomByMousePosition(DependencyObject obj, bool value)
        {
            obj.SetValue(IsEnableZoomByMousePositionProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsEnableZoomByMousePosition.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsEnableZoomByMousePositionProperty =
            DependencyProperty.RegisterAttached(
                "IsEnableZoomByMousePosition", typeof(bool), typeof(ZoomByMousePositionHelper),
                new PropertyMetadata(false, OnIsEnableZoomByMousePositionChanged));

        public static readonly DependencyProperty BehaviorProperty =
         DependencyProperty.RegisterAttached(
             "Behavior",
             typeof(ZoomByMousePositionHelper),
             typeof(ZoomByMousePositionHelper),
             new PropertyMetadata(null));



        private static void OnIsEnableZoomByMousePositionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as ScrollViewer;

            if ((bool)e.NewValue)
            {
                ZoomByMousePositionHelper behaviour =
                    new ZoomByMousePositionHelper();

                element.ScrollChanged += behaviour.scrollViewer1_ScrollChanged;
                element.PreviewMouseMove += behaviour.OnPreviewMouseMove;
            }
            else
            {
                //ZoomByMousePositionHelper behaviour = 
                //    element.GetValue(BehaviorProperty) as ZoomByMousePositionHelper;

                //element.ScrollChanged -= scrollViewer1_ScrollChanged;
                //dettach the behavior
                ZoomByMousePositionHelper behavior = element.GetValue(BehaviorProperty) as ZoomByMousePositionHelper;
                if (behavior != null)
                {
                    element.ScrollChanged -= behavior.scrollViewer1_ScrollChanged;
                    element.PreviewMouseMove -= behavior.OnPreviewMouseMove;
                }

                element.SetValue(BehaviorProperty, null);

            }
        }
        Point ZoomPoint;
        double percentage_extent_X;
        double percentage_extent_Y;
        double percentage_viewport_X;
        double percentage_viewport_Y;

        private void scrollViewer1_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {

            ScrollViewer scroll = sender as ScrollViewer;
            if (e.ExtentWidthChange != 0 || e.ExtentHeightChange != 0)
            {

                scroll.ScrollToHorizontalOffset(CalculateOffsetMousePosition(e.ExtentWidth, e.ViewportWidth, scroll.ScrollableWidth, percentage_extent_X, percentage_viewport_X));
                scroll.ScrollToVerticalOffset(CalculateOffsetMousePosition(e.ExtentHeight, e.ViewportHeight, scroll.ScrollableHeight, percentage_extent_Y, percentage_viewport_Y));
            }
            else
            {

            }

        }
        private static double CalculateOffsetMousePosition(double extent, double viewPort, double scrollable, double relBefore, double percentage_view)
        {
            double offset = relBefore * extent - percentage_view * viewPort;
            if (offset < 0)
            {
                //center the content
                //this can be set to 0 if center by default is not needed
                //offset = 0.5 * scrollable;
                offset = 0;
            }
            return offset;
        }


        private void OnPreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var scroll_viewer = sender as ScrollViewer;

            ZoomPoint = e.GetPosition(scroll_viewer);

            percentage_extent_X = (scroll_viewer.HorizontalOffset + ZoomPoint.X) / scroll_viewer.ExtentWidth;
            percentage_extent_Y = (scroll_viewer.VerticalOffset + ZoomPoint.Y) / scroll_viewer.ExtentHeight;

            percentage_viewport_X = ZoomPoint.X / scroll_viewer.ViewportWidth;
            percentage_viewport_Y = ZoomPoint.Y / scroll_viewer.ViewportHeight;

        }
    }
}

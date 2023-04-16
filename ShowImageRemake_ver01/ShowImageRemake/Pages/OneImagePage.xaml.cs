using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShowImageRemake.Pages
{
    /// <summary>
    /// Interaction logic for OneImagePage.xaml
    /// </summary>
    public partial class OneImagePage : Page
    {
        public OneImagePage()
        {
            InitializeComponent();
        }
        ImageControls.GifImageControl Global_imageButton;
        public OneImagePage(string image_path)
        {
            InitializeComponent();

            var imageButton = new ImageControls.GifImageControl(image_path);
            Global_imageButton = imageButton;

            button.Content = imageButton;
        

            fitWindowButton.Checked += (sender, routedEventArgs) =>
            {
                Global_imageButton.Height = ((System.Windows.Controls.DockPanel)Application.Current.MainWindow.Content).ActualHeight;
                Global_imageButton.Width = ((System.Windows.Controls.DockPanel)Application.Current.MainWindow.Content).ActualWidth;
                var st = GetScaleTransform(button as FrameworkElement);
                st.ScaleX = 1;
                st.ScaleY = 1;

                scroll_viewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
                scroll_viewer.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
                SizeChanged += Window_SizeChanged;
            };

            fitWindowButton.Unchecked += (sender, routedEventArgs) =>
            {
                var st = GetScaleTransform(button as FrameworkElement);
                st.ScaleX = 1;
                st.ScaleY = 1;
                scroll_viewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                scroll_viewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                SizeChanged -= Window_SizeChanged;
            };






            content = button;
            button.PreviewMouseLeftButtonDown += OnPreviewMouseLeftButtonDown;
            button.PreviewMouseMove += OnPreviewMouseMove;
            button.PreviewMouseLeftButtonUp += OnPreviewMouseLeftButtonUp;





        }
        private static ScaleTransform GetScaleTransform(FrameworkElement element)
        {
            return (ScaleTransform)((TransformGroup)element.LayoutTransform).Children.First(tr => tr is ScaleTransform);
        }
        void Window_SizeChanged(object sender,SizeChangedEventArgs sizeChangedEventArgs)
        {
            Global_imageButton.Height = sizeChangedEventArgs.NewSize.Height;
            Global_imageButton.Width = sizeChangedEventArgs.NewSize.Width;
        }





        private UIElement content;
        private Point scrollMousePoint;
        private double scrollHorizontalOffset;
        private double scrollVerticalOffset;
        bool Ispressed = false;
        bool DontMoveToNextPage = false;
        private void OnPreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            content.CaptureMouse();

            scrollMousePoint = e.GetPosition(scroll_viewer);
            scrollHorizontalOffset = scroll_viewer.HorizontalOffset;//Get ScrollViewer's HorizontalOffset
            scrollVerticalOffset = scroll_viewer.VerticalOffset;
            Ispressed = true;
            DontMoveToNextPage = false;
        }

        private void OnPreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {

            if (Ispressed == false)
                return;

            bool IsBiggerThanMin_X_DragDistance = (Math.Abs(scrollMousePoint.X - e.GetPosition(scroll_viewer).X) > 5);

            bool IsBiggerThanMin_Y_DragDistance = (Math.Abs(scrollMousePoint.Y - e.GetPosition(scroll_viewer).Y) > 5);

            if (IsBiggerThanMin_X_DragDistance || IsBiggerThanMin_Y_DragDistance)
            {
                DontMoveToNextPage = true;
                scroll_viewer.Cursor = Cursors.Hand;
                //Console.WriteLine("trigger");
            }


            if (content.IsMouseCaptured)
            {
                var move_distance_Y = scrollMousePoint.Y - e.GetPosition(scroll_viewer).Y;
                var move_distance_X = scrollMousePoint.X - e.GetPosition(scroll_viewer).X;
                var newVerticalOffset = scrollVerticalOffset + move_distance_Y;
                var newHorizontalOffset = scrollHorizontalOffset + move_distance_X;


                scroll_viewer.ScrollToVerticalOffset(newVerticalOffset);
                scroll_viewer.ScrollToHorizontalOffset(newHorizontalOffset);

            }



        }

        private void OnPreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {


            if (DontMoveToNextPage == false)
            {

                //Page parent_page = Utils.GetDependencyObjectFromVisualTree(this, typeof(Page)) as Page;
                //OneImagePage parent_page = Utils.GetDependencyObjectFromVisualTree(this, typeof(OneImagePage)) as OneImagePage;
                Global_imageButton.Stop();
                //WPF_Pages.RightLeftBrowseImagePage newPage = new WPF_Pages.RightLeftBrowseImagePage();
                //parent_page.
                //NavigationService.Navigate(PagesDataContext.right_left_page);
                NavigationService.Navigate(MyDataContext.PageDataContext.applePage);
            }


            content.ReleaseMouseCapture();
            scroll_viewer.Cursor = Cursors.Arrow;
            Ispressed = false;
            //Console.WriteLine("c");
        }
    
    
    
    }
}

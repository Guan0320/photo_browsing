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
using System.Windows.Navigation;

namespace ShowImageRemake.Pages
{
    /// <summary>
    /// Interaction logic for ApplePage.xaml
    /// </summary>
    public partial class ApplePage : Page
    {
        public ApplePage()
        {
            Initialized += init;//This should be placed before InitializeComponent();
            void init(object sender, EventArgs e)
            {
                Binding myBinding = new Binding()
                {
                    Path = new PropertyPath("Content.ImagePath"),
                    Mode = BindingMode.TwoWay,
                    Source = middleButton
                };
                BindingOperations.SetBinding(ImagePathTextBox, TextBox.TextProperty, myBinding);

                //next page
                middleButton.Click += (adad, args) =>
                {
                    var button_temp = adad as Button;
                    var image_control_temp = button_temp.Content as ImageControls.AsyncImage;

                    Pages.OneImagePage nextPage = new OneImagePage(image_control_temp.ImagePath);
                    MyDataContext.PageDataContext.applePage = this;
                    NavigationService.Navigate(nextPage);

                };
                middleButton.Content = new ImageControls.AsyncImage(@"C:\Users\林冠廷\Desktop\各種檔案名稱\test.gif");

                slider.ValueChanged += Slider_ValueChanged;

                Drop += ImagePanel_Drop;



            }

            InitializeComponent();
        }

        private async void ImagePanel_Drop(object sender, DragEventArgs e)
        {
            middleButton.Visibility = Visibility.Visible;
            string[] files = new string[1]{"aaa"};
            Console.WriteLine(files[0]);
            Console.WriteLine("a");
            //get file data
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (e.Data.GetDataPresent(DataFormats.Html))
                Console.WriteLine("this is html");

            
            //check is file available
            if (Extensions.CheckImageExtension.IsFileAvailable(files[0]) == false)
            {

                await Task.Yield();
                Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(String.Format("This app didnt support the file Extension:{0}", System.IO.Path.GetExtension(files[0])));
                    Console.WriteLine("window_args_mouse_move");
                });

                return;
            }

            //
            _imageDirectory = System.IO.Path.GetDirectoryName(files[0]);
            imagePaths = System.IO.Directory
                .GetFiles(_imageDirectory, "*.*")
                .Where(file => Extensions.CheckImageExtension.IsFileAvailable(file))
                .ToList().ToArray();
            image_controls.Clear();
            var middle_image_index = Array.IndexOf(imagePaths, files[0]);

            slider.Maximum = imagePaths.Length - 1;

            if (slider.Value == middle_image_index)
            {
                if (image_controls.ContainsKey(middle_image_index) == false)
                {
                    ImageControls.AsyncImage image_temp = new ImageControls.AsyncImage(imagePaths[middle_image_index]);
                    image_controls.Add(middle_image_index, image_temp);
                }

                middleButton.Content = image_controls[middle_image_index];

                add_right(middle_image_index);
                add_left(middle_image_index);


            }
            else
            {
                slider.Value = middle_image_index;//this will trigger slider.ValueChanged

            }



        }




        string _imageDirectory;
        string[] imagePaths;
        Dictionary<int, ImageControls.AsyncImage> image_controls = new Dictionary<int, ImageControls.AsyncImage>();

        void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Console.WriteLine("Slider_ValueChanged");
            var slider_sender = sender as Slider;


            if (_imageDirectory == null)
            {
                return;
            }

            //if (image_controls.ContainsKey(-1) == false)
            //{
            //    ImageControl image_temp = new ImageControl(@"C:\Users\林冠廷\Desktop\100759472_p0_master1200.jpg");
            //    image_controls.Add(-1, image_temp);
            //}
            if (image_controls.ContainsKey((int)e.NewValue) == false)
            {
                ImageControls.AsyncImage image_temp = new ImageControls.AsyncImage(imagePaths[(int)e.NewValue]);
                image_controls.Add((int)e.NewValue, image_temp);
            }
            //add middle image
            //middleButton.Content = null;
            //middleButton.Content = image_controls[-1];
            middleButton.Content = image_controls[(int)e.NewValue];


            add_right((int)e.NewValue);
            add_left((int)e.NewValue);



        }

        void add_right(int middle_index)
        {
            stack_panel_right.Children.Clear();
            var next_image_index = middle_index + 1;
            int load_number = 6;
            // load_number = int.MaxValue;

            int i = 0;
            while (next_image_index != imagePaths.Length && i < load_number)
            {
                i++;
                if (image_controls.ContainsKey(next_image_index) == false)
                {
                    ImageControls.AsyncImage image_temp = new ImageControls.AsyncImage(imagePaths[next_image_index]);
                    image_controls.Add(next_image_index, image_temp);
                }



                Button button = new Button();
                stack_panel_right.Children.Add(button);

                button.Content = image_controls[next_image_index];
                button.Click += (sender_button, b) =>
                {

                    //bool_can_enter_next_page = false;
                    //middleButton.IsHitTestVisible = false;


                    Button button_temp = sender_button as Button;

                    //Mouse.Capture(button_temp);
                    button_temp.CaptureMouse();

                    var image_path = (button_temp.Content as ImageControls.AsyncImage).ImagePath;
                    var middle_image_index = Array.IndexOf(imagePaths, image_path);
                    slider.Value = middle_image_index;

                    button_temp.ReleaseMouseCapture();
                };
                next_image_index = next_image_index + 1;
            }
        }


        void add_left(int middle_index)
        {
            stack_panel_left.Children.Clear();

            var previous_image_index = Math.Max(0, middle_index - 5);
            int load_number = 6;
            // load_number = int.MaxValue;

            int i = 0;
            while (previous_image_index != middle_index && i < load_number)
            {
                i++;
                if (image_controls.ContainsKey(previous_image_index) == false)
                {
                    ImageControls.AsyncImage image_temp = new ImageControls.AsyncImage(imagePaths[previous_image_index]);
                    image_controls.Add(previous_image_index, image_temp);
                }



                Button button = new Button();
                stack_panel_left.Children.Add(button);

                button.Content = image_controls[previous_image_index];
                button.Click += (sender_button, b) =>
                {


                    Button button_temp = sender_button as Button;

                    //Mouse.Capture(button_temp);
                    button_temp.CaptureMouse();

                    var image_path = (button_temp.Content as ImageControls.AsyncImage).ImagePath;
                    var middle_image_index = Array.IndexOf(imagePaths, image_path);
                    slider.Value = middle_image_index;

                    button_temp.ReleaseMouseCapture();
                };
                previous_image_index = previous_image_index + 1;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pages.OneImagePage a = new Pages.OneImagePage();
            NavigationService.Navigate(a);
        }
    }
}

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

namespace ShowImageRemake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {

        public MainWindow()
        {
            InitializeComponent();
            button_Setting.Click += (g, h) =>
            {
                //Console.WriteLine("buttonOnLeft.Click");
                SettingWindow win2 = new SettingWindow();
                win2.Show();

            };
            Pages.ApplePage a = new Pages.ApplePage();

            frame.Navigate(a);

            KeyDown += Window_KeyDown;
            KeyUp += Window_KeyUp;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Window_KeyDown");
            // If the system key is down...
            if (e.Key == Key.System)
            {
                // Track it
                
                MyDataContext.AltControlDataContext.mSystemKeyIsDown = true;
            }
                
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            // On system key up...
            if (e.Key == Key.System)
            {
                // Track it
                MyDataContext.AltControlDataContext.mSystemKeyIsDown = false;

                // If we had scrolled with the system key down...
                if (MyDataContext.AltControlDataContext.mHasScrolledWithSystemKeyDown)
                    // Cause a small delay to allow this key up to process
                    Task.Delay(0).ContinueWith((t) => Dispatcher.Invoke(() =>
                    {
                        // Then focus the last control to "close" the system menu gracefully
                        MyDataContext.AltControlDataContext.mLastFocusedControl?.Focus();
                    }));

                // Flag the has scrolled to false to start again
                MyDataContext.AltControlDataContext.mHasScrolledWithSystemKeyDown = false;
            }
        }

    }
}

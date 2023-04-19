using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;

namespace ShowImageRemake.ImageControls
{
    public class AsyncImage : Image
    {
        public static readonly DependencyProperty ImagePathProperty =
            DependencyProperty.Register(
                nameof(ImagePath), typeof(string), typeof(AsyncImage),
                new PropertyMetadata(async (o, e) =>
                    await ((AsyncImage)o).LoadImageAsync((string)e.NewValue)));

        public string ImagePath
        {
            get { return (string)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }
        public AsyncImage(string path)
        {
            ImagePath = path;
        }
        private async Task LoadImageAsync(string imagePath)
        {
            Source = await Task.Run(() =>
            {
                using (var stream = File.OpenRead(imagePath))
                {
                    var bi = new BitmapImage();
                    bi.BeginInit();
                    bi.CacheOption = BitmapCacheOption.OnLoad;
                    bi.StreamSource = stream;
                    bi.EndInit();
                    bi.Freeze();
                    return bi;
                }
            });
        }
    }

}

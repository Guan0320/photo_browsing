using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Threading;
using System.Drawing;
using System.Windows.Interop;
using System.Runtime.InteropServices;



using System.Windows.Media;

using System.Windows.Input;

namespace ShowImageRemake.ImageControls
{
    public class GifImageControl : System.Windows.Controls.Image
    {
        /// <inheritdoc />
        public GifImageControl()
        {
        }

        /// <inheritdoc />
        public GifImageControl(string path)
        {
            ImagePath = path;
        }
        private string _image_path;
        public string ImagePath
        {
            get => _image_path;
            set
            {
                if (!File.Exists(value))
                {
                    var file = new FileInfo(value);
                    if (!file.Exists)
                    {
                        throw new ArgumentException("找不到文件" + value);
                    }
                    else if (file.Exists)
                    {
                        value = file.FullName;
                    }

                }

                _image_path = value;
                Start();
            }
        }

        /// <summary>
        ///     播放图片
        /// </summary>
        public void Start()
        {
            if (_bitmap != null)
            {
                //多次点击播放，如果没有停止，会让上一个图片还在播放
                Stop();
            }

            var path = ImagePath;
            _bitmap = (Bitmap)System.Drawing.Image.FromFile(path);//System.Drawing.Image to System.Drawing.Bitmap


            //the first image
            _bitmapSource = GetBitmapSource_FromBitmap();
            Source = _bitmapSource;

            ImageAnimator.Animate(_bitmap, OnFrameChanged);


        }

        /// <summary>
        ///     停止播放
        /// </summary>
        public void Stop()
        {
            if (_bitmap == null)
            {
                return;
            }

            ImageAnimator.StopAnimate(_bitmap, OnFrameChanged);
            _bitmap.Dispose();
            _bitmap = null;
        }

        private Bitmap _bitmap;
        private BitmapSource _bitmapSource;



        private void OnFrameChanged(object sender, EventArgs e)
        {
            //https://blog.walterlv.com/post/dotnet/2017/09/26/dispatcher-invoke-async.html
            Dispatcher.InvokeAsync(OnFrameChangedInMainThread);

            //Dispatcher.BeginInvoke(
            //    DispatcherPriority.Normal,
            //    (ThreadStart)delegate () { OnFrameChangedInMainThread(); }    
            //    );
        }

        int count = 0;
        private void OnFrameChangedInMainThread()
        {
            ImageAnimator.UpdateFrames();

            _bitmapSource = GetBitmapSource_FromBitmap();
            Source = _bitmapSource;





            this.InvalidateVisual();


        }

        private BitmapSource GetBitmapSource_FromBitmap()
        {
            IntPtr inptr = _bitmap.GetHbitmap();
            _bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(
                bitmap: inptr, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            DeleteObject(inptr);
            return _bitmapSource;
        }

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteObject(IntPtr hObject);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
namespace ShowImageRemake.Extensions
{
    internal class CheckImageExtension
    {
        public static DependencyObject GetDependencyObjectFromVisualTree(DependencyObject startObject, Type type)

        {
            int i = 0;
            //Walk the visual tree to get the parent(ItemsControl)
            //of this control

            DependencyObject parent = startObject;
            while (parent != null)
            {
                // Console.WriteLine(i);
                i++;
                //Console.WriteLine(parent.GetType());
                if (type.IsInstanceOfType(parent))
                    break;
                else
                    parent = VisualTreeHelper.GetParent(parent);
            }
            return parent;
        }

        public static bool IsFileAvailable(string file_string)
        {
            var file_extension = System.IO.Path.GetExtension(file_string).ToLower();

            List<string> list_extension = new List<string>();
            Console.WriteLine("hi");
            list_extension.Add(".jpg");
            list_extension.Add(".jfif");
            list_extension.Add(".jpeg");
            //list_extension.Add(".clip");
            list_extension.Add(".png");
            list_extension.Add(".gif");
            list_extension.Add(".webp");
            Console.WriteLine(file_extension);
            foreach (var extension in list_extension)
            {
                if (file_extension == extension)
                {
                    return true;
                }
            }
            return false;

        }

        public static bool IsImageType(string file_string)
        {
            var file_extension = System.IO.Path.GetExtension(file_string).ToLower();

            List<string> list_extension = new List<string>();

            list_extension.Add(".jpg");
            list_extension.Add(".jfif");
            list_extension.Add(".jpeg");
            //list_extension.Add(".clip");
            list_extension.Add(".png");


            foreach (var extension in list_extension)
            {
                if (file_extension == extension)
                {
                    return true;
                }
            }
            return false;

        }
    }
}

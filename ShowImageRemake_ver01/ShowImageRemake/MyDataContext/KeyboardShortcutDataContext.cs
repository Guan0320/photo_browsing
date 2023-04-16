using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace ShowImageRemake.MyDataContext
{
    internal class KeyboardShortcutDataContext
    {
        public static ModifierKeys ZoomShortcut =
        (ModifierKeys)new ModifierKeysConverter().
        ConvertFrom(null, null,
            Properties.Settings.Default.SysZoomShortcut);

        //public static string b = ModifierKeysConverter.

        public static ModifierKeys HorizontallyScrollShortcut =
            (ModifierKeys)new ModifierKeysConverter().
            ConvertFrom(null, null,
                Properties.Settings.Default.SysHorizontallyScrollShortcut);



        public static ModifierKeys VerticallyScrollShortcut =
            (ModifierKeys)new ModifierKeysConverter().
            ConvertFrom(null, null,
                Properties.Settings.Default.SysVerticallyScrollShortcut);
    }
}

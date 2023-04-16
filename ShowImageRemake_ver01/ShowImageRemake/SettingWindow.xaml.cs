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
using System.Windows.Shapes;

namespace ShowImageRemake
{
    /// <summary>
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow
    {
        public SettingWindow()
        {
            InitializeComponent();
            List<string> listOfModifiers = new List<string> { "無", "ctrl", "shift", "alt" };
            #region ---   ZoomByMousePosition   ---
            comboBox_Zoom.ItemsSource = listOfModifiers;
            switch (MyDataContext.KeyboardShortcutDataContext.ZoomShortcut)
            {
                case ModifierKeys.None:
                    comboBox_Zoom.SelectedIndex = listOfModifiers.IndexOf("無");
                    break;
                case ModifierKeys.Control:
                    comboBox_Zoom.SelectedIndex = listOfModifiers.IndexOf("ctrl");
                    break;
                case ModifierKeys.Shift:
                    comboBox_Zoom.SelectedIndex = listOfModifiers.IndexOf("shift");
                    break;
                case ModifierKeys.Alt:
                    comboBox_Zoom.SelectedIndex = listOfModifiers.IndexOf("alt");
                    break;

                default:
                    break;

            }
            comboBox_Zoom.SelectionChanged += (sender, args) =>
            {
                var newSelectedModifierKey = comboBox_Zoom.SelectedValue.ToString().Trim().ToUpper();
                switch (newSelectedModifierKey)
                {
                    case "無":
                        MyDataContext.KeyboardShortcutDataContext.ZoomShortcut = ModifierKeys.None;
                        Properties.Settings.Default.SysZoomShortcut = "";
                        Properties.Settings.Default.Save();
                        break;

                    case "CONTROL":
                    case "CTRL":
                        MyDataContext.KeyboardShortcutDataContext.ZoomShortcut = ModifierKeys.Control;
                        Properties.Settings.Default.SysZoomShortcut = "Control";
                        Properties.Settings.Default.Save();
                        break;

                    case "SHIFT":
                        MyDataContext.KeyboardShortcutDataContext.ZoomShortcut = ModifierKeys.Shift;
                        Properties.Settings.Default.SysZoomShortcut = "Shift";
                        Properties.Settings.Default.Save();
                        break;

                    case "ALT":
                        MyDataContext.KeyboardShortcutDataContext.ZoomShortcut = ModifierKeys.Alt;
                        Properties.Settings.Default.SysZoomShortcut = "Alt";
                        Properties.Settings.Default.Save();
                        break;



                    default:

                        break;
                }
            };
            #endregion

            #region ---  VerticallyScroll    ---
            var a = comboBox_VerticallyScroll;
            a.ItemsSource = listOfModifiers;
            switch (MyDataContext.KeyboardShortcutDataContext.VerticallyScrollShortcut)
            {
                case ModifierKeys.None:
                    a.SelectedIndex = listOfModifiers.IndexOf("無");
                    break;
                case ModifierKeys.Control:
                    a.SelectedIndex = listOfModifiers.IndexOf("ctrl");
                    break;
                case ModifierKeys.Shift:
                    a.SelectedIndex = listOfModifiers.IndexOf("shift");
                    break;
                case ModifierKeys.Alt:
                    a.SelectedIndex = listOfModifiers.IndexOf("alt");
                    break;

                default:
                    break;

            }
            a.SelectionChanged += (sender, args) =>
            {
                var newSelectedModifierKey = a.SelectedValue.ToString().Trim().ToUpper();
                switch (newSelectedModifierKey)
                {
                    case "無":
                        MyDataContext.KeyboardShortcutDataContext.VerticallyScrollShortcut = ModifierKeys.None;
                        Properties.Settings.Default.SysVerticallyScrollShortcut = "";
                        Properties.Settings.Default.Save();
                        break;

                    case "CONTROL":
                    case "CTRL":
                        MyDataContext.KeyboardShortcutDataContext.VerticallyScrollShortcut = ModifierKeys.Control;
                        Properties.Settings.Default.SysVerticallyScrollShortcut = "Control";
                        Properties.Settings.Default.Save();
                        break;

                    case "SHIFT":
                        MyDataContext.KeyboardShortcutDataContext.VerticallyScrollShortcut = ModifierKeys.Shift;
                        Properties.Settings.Default.SysVerticallyScrollShortcut = "Shift";
                        Properties.Settings.Default.Save();
                        break;

                    case "ALT":
                        MyDataContext.KeyboardShortcutDataContext.VerticallyScrollShortcut = ModifierKeys.Alt;
                        Properties.Settings.Default.SysVerticallyScrollShortcut = "Alt";
                        Properties.Settings.Default.Save();
                        break;



                    default:

                        break;
                }
            };

            #endregion

            #region --- HorizontallyScroll  ---
            var b = comboBox_HorizontallyScroll;
            b.ItemsSource = listOfModifiers;
            switch (MyDataContext.KeyboardShortcutDataContext.HorizontallyScrollShortcut)
            {
                case ModifierKeys.None:
                    b.SelectedIndex = listOfModifiers.IndexOf("無");
                    break;
                case ModifierKeys.Control:
                    b.SelectedIndex = listOfModifiers.IndexOf("ctrl");
                    break;
                case ModifierKeys.Shift:
                    b.SelectedIndex = listOfModifiers.IndexOf("shift");
                    break;
                case ModifierKeys.Alt:
                    b.SelectedIndex = listOfModifiers.IndexOf("alt");
                    break;

                default:
                    break;

            }
            b.SelectionChanged += (sender, args) =>
            {
                var newSelectedModifierKey = b.SelectedValue.ToString().Trim().ToUpper();
                switch (newSelectedModifierKey)
                {
                    case "無":
                        MyDataContext.KeyboardShortcutDataContext.HorizontallyScrollShortcut = ModifierKeys.None;
                        Properties.Settings.Default.SysHorizontallyScrollShortcut = "";
                        Properties.Settings.Default.Save();
                        break;

                    case "CONTROL":
                    case "CTRL":
                        MyDataContext.KeyboardShortcutDataContext.HorizontallyScrollShortcut = ModifierKeys.Control;
                        Properties.Settings.Default.SysHorizontallyScrollShortcut = "Control";
                        Properties.Settings.Default.Save();
                        break;

                    case "SHIFT":
                        MyDataContext.KeyboardShortcutDataContext.HorizontallyScrollShortcut = ModifierKeys.Shift;
                        Properties.Settings.Default.SysHorizontallyScrollShortcut = "Shift";
                        Properties.Settings.Default.Save();
                        break;

                    case "ALT":
                        MyDataContext.KeyboardShortcutDataContext.HorizontallyScrollShortcut = ModifierKeys.Alt;
                        Properties.Settings.Default.SysHorizontallyScrollShortcut = "Alt";
                        Properties.Settings.Default.Save();
                        break;



                    default:

                        break;
                }
            };

            #endregion
        }
    }
}

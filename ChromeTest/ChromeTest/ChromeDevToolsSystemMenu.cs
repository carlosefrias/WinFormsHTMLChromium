using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ChromeTest
{
    internal static class ChromeDevToolsSystemMenu
    {
        // P/Invoke constants
        public const int WmSysCommand = 0x112;
        private const int MfString = 0x0;
        private const int MfSeparator = 0x800;

        // P/Invoke declarations
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool AppendMenu(IntPtr hMenu, int uFlags, int uIdNewItem, string lpNewItem);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool InsertMenu(IntPtr hMenu, int uPosition, int uFlags, int uIdNewItem, string lpNewItem);

        // ID for the Chrome dev tools item on the system menu
        public static int SYSMENU_CHROME_DEV_TOOLS = 0x1;

        public static void CreateSysMenu(Form frm)
        {
            // in your form override the OnHandleCreated function and call this method e.g:
            // protected override void OnHandleCreated(EventArgs e)
            // {
            //     ChromeDevToolsSystemMenu.CreateSysMenu(frm,e);
            // }

            // Get a handle to a copy of this form's system (window) menu
            IntPtr hSysMenu = GetSystemMenu(frm.Handle, false);

            // Add a separator
            AppendMenu(hSysMenu, MfSeparator, 0, string.Empty);

            // Add the About menu item
            AppendMenu(hSysMenu, MfString, SYSMENU_CHROME_DEV_TOOLS, "&Chrome Dev Tools");
        }
    }
}

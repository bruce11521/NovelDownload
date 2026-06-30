using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CoreBase.Winform
{
    /// <summary>
    /// 自定義DateTimePicker
    /// </summary>
    [Description("日期選擇器，彈出後的字體大小會一起調整")]
    public class MyDateTimePicker : DateTimePicker
    {
        /*
            置換成DateTimePicker Popup出來能字體能修正的步驟
            如修正現在的UI，請跳過1，直接操作2使用即可
            
            1.從工具箱拉出 DateTimePicker
            2.從UI的Designer.cs檔案，將『System.Windows.Forms.DateTimePicker()』全面置換成 『HIS2_CoreBase.WinForm.MyDateTimePicker()』即可


            另一個使用方式，直接從工具箱拉出來使用
         * 
         */

        private const int SWP_NOMOVE = 0x0002;
        private const int DTM_First = 0x1000;
        private const int DTM_GETMONTHCAL = DTM_First + 8;
        private const int MCM_GETMINREQRECT = DTM_First + 9;

        [DllImport("uxtheme.dll")]
        private static extern int SetWindowTheme(IntPtr hWnd, string appName, string idList);
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, ref RECT lParam);
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,
        int X, int Y, int cx, int cy, int uFlags);
        [DllImport("User32.dll")]
        private static extern IntPtr GetParent(IntPtr hWnd);
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT { public int L, T, R, B; }
        protected override void OnDropDown(EventArgs eventargs)
        {
            var hwndCalendar = SendMessage(this.Handle, DTM_GETMONTHCAL, 0, 0);
            SetWindowTheme(hwndCalendar, string.Empty, string.Empty);
            var r = new RECT();
            SendMessage(hwndCalendar, MCM_GETMINREQRECT, 0, ref r);
            var hwndDropDown = GetParent(hwndCalendar);
            SetWindowPos(hwndDropDown, IntPtr.Zero, 0, 0,
                r.R - r.L + 6, r.B - r.T + 6, SWP_NOMOVE);
            base.OnDropDown(eventargs);
        }
    }
}

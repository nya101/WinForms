using System;
using System.Windows.Forms;

namespace WinFormsAssignmentTwoApp2
{
    internal static class ProgramBase
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
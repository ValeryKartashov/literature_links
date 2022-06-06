using System;
using System.Windows.Forms;

namespace TRPO_Kartashov_AS41
{
    internal static class Program
    {
        #region Method

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        #endregion
    }
}

using System;
using System.Windows.Forms;

namespace COMP1019_Lab08_SimplePaint
{
    internal static class Program
    {
        /// <summary>
        /// Điểm bắt đầu của chương trình.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmPaint());
        }
    }
}

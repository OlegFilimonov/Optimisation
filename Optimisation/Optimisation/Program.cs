using System;
using System.Windows.Forms;
using Optimisation.Оформление;

namespace Optimisation
{
    //Основной класс программы
    internal class Program
    {
        [STAThread]
        // ReSharper disable once ObjectCreationAsStatement
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Запускаем форму
            var form = new MainForm();
            Application.Run(form);
        }
    }
}
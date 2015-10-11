using System;
using System.Windows.Forms;

namespace Optimisation
{
    //Основной класс программы
    class Program
    {
        [STAThread]
        // ReSharper disable once ObjectCreationAsStatement
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Запускаем форму
            var form = new MainForm();
            Application.Run(form);
        }
    }
}

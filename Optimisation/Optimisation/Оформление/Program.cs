using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Optimisation.Testing;

namespace Optimisation
{
    //Основной класс программы
    class Program
    {
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

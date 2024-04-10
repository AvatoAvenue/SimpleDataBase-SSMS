using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static sql_topicos_sc.forms;
using static sql_topicos_sc.procedure;

namespace sql_topicos_sc
{
    internal static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            procedure p = new procedure();
            p.inicio();
        }


    }
}

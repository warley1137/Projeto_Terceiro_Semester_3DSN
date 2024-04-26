using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SK8TOONY.classes;

namespace SK8TOONY
{
    internal static class Program
    {
        //Telas
        public static Login telaLogin;
        public static Cadastro telaCadastro;
        public static Main telaPrincipal;
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Apresentacao());
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileMoverApp;

namespace FileMover
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(HandleUIThreadExceptions);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(HandleNonUIThreadExceptions);

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        // Tratamento de exceções de UI (Thread Principal)
        private static void HandleUIThreadExceptions(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            LogError(e.Exception, "UI Thread Exception");
        }

        // Tratamento de exceções fora da UI (outras threads)
        private static void HandleNonUIThreadExceptions(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                LogError(ex, "Non-UI Thread Exception");
            }
        }

        // Função para gravar o erro no log
        private static void LogError(Exception ex, string context)
        {
            string logFilePath = @"C:\temp\error_log.txt";
            Directory.CreateDirectory(Path.GetDirectoryName(logFilePath)); // Garante que a pasta existe
            File.AppendAllText(logFilePath, $"{DateTime.Now}: {context}\n{ex.Message}\n{ex.StackTrace}\n\n");

            MessageBox.Show("Ocorreu um erro. Detalhes foram gravados no log: " + logFilePath, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

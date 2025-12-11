using EGAIP.API.a_p_i;
using EGAIP.API.Forms;

namespace EGAIP
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var userapi = new UserAPI("https://localhost:7414");
            Application.Run(new LoginForm(userapi));
        }
    }
}
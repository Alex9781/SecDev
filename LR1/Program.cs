namespace LR1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                MessageBox.Show("Debugger is attached");
                return;
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            AuthForm authForm = new AuthForm();
            Application.Run(authForm);
        }
    }
}
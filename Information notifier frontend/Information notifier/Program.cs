namespace Information_notifier
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        //static void Main() // debug
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(Int32.Parse(args[0]))); // bound port in the argument
            //Application.Run(new Form1(Int32.Parse("9000"))); // debug
        }
    }
}
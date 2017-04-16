namespace Pokemon.Client
{
    using Data;
    using System;
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Utils.InitDB();
            using (var game = new Game1())
                game.Run();
        }
    }
#endif
}

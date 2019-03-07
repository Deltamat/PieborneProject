using System;

namespace Pieborne
{
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
        public static void Main()
        {
            using (var game = GameWorld.Instance)
            {
                game.Run();
            }
        }
    }
#endif
}

using System;

namespace Plugin.MaterialDesignControls.Utils
{
    public static class LoggerHelper
    {
        private const string Prefix = "[Plugin.MaterialDesignControls]";

        public static void Log(Exception ex)
        {
            Console.WriteLine($"{Prefix} - {ex.Message} - {ex.StackTrace}");
        }
    }
}
using System;
using System.IO;

namespace Homework_4.JSON
{
    public class ExtendedJsonReader
    {
        public static string ReadFile()
        {
            string pathToFile = default;
            try
            {
                pathToFile = File.ReadAllText("appsettings.json");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"File cannot read - {ex.Message}");
            }

            return pathToFile;
        }
    }
}
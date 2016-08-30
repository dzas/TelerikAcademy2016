﻿class Writer
{
    private const int MaxCount = 6;
    private class ConsoleWriter
    {
        public void WriteBoolToConsole(bool isTrue)
        {
            string boolString = isTrue.ToString();
            Console.WriteLine(boolString);
        }
    }

    public static void WriteTrueToConsole()
    {
        Writer.ConsoleWriter consoleWriter = new Writer.ConsoleWriter();
        consoleWriter.WriteBoolToConsole(true);
    }
}
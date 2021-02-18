namespace DL.FileConverter.Console.Helpers
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string content)
        {
            System.Console.WriteLine(content);
            System.Console.ReadLine();
        }
    }
}

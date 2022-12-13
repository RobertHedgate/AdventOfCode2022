namespace Helpers
{
    public class File
    {
        public string Read(string path)
        {
            string text = System.IO.File.ReadAllText(path);

            return text;
        }
        public string[] ReadLines(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);

            return lines;
        }
    }
}
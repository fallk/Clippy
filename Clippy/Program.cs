using System;
using System.Windows.Forms;

namespace Clippy
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                foreach (var s in args)
                {
                    var t = TextDataFormat.Text;
                    switch (s)
                    {
                        case "html":
                            t = TextDataFormat.Html;
                            break;
                        case "rtf":
                            t = TextDataFormat.Rtf;
                            break;
                        case "csv":
                            t = TextDataFormat.CommaSeparatedValue;
                            break;
                        case "-h":
                        case "--help":
                        case "-help":
                        case "/?":
                            Console.WriteLine("Clippy");
                            Console.WriteLine();
                            Console.WriteLine("  Usage: ");
                            Console.WriteLine("  - clippy [html|rtf|csv|<empty>]: Get clipboard text in a format. If not specified, the format is plain text.");
                            Console.WriteLine("  - clippy -h: Show this help message.");
                            Environment.Exit(0);
                            break;
                        default:
                            t = TextDataFormat.Text;
                            break;
                    }
                    if (Clipboard.ContainsText(t))
                    {
                        Console.Write(Clipboard.GetText(t));
                    }
                    else
                    {
                        // print any clipboard content
                        Console.Write(Clipboard.GetText());
                        // exit with error
                        Environment.Exit(1);
                    }
                }
            }
            else
            {
                Console.Write(Clipboard.GetText(TextDataFormat.Html));
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextConverter
{
    internal class Class1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Напишите текст который хотите сохранить: ");
                string consoleText = Console.ReadLine();
                Console.WriteLine("Выберите [1] для сохранения в формате TXT\n Выберите [2] для сохранения в формате xlm\n Выберите [3] для сохранения в формате json");
                string format = Console.ReadLine();
                WriteFile wf = new WriteFile();

                switch (format)
                {
                    case "1":
                        wf.WriteToFile(consoleText, "txt");
                        Console.WriteLine($"Файл сохранен в формате .txt {Environment.CurrentDirectory}");
                        break;
                    case "2":
                        {
                            consoleText = consoleText.Replace(" ", ";");
                            wf.WriteToFile(consoleText, "xlm");
                            Console.WriteLine($"Файл сохранен в формате .xlm + {Environment.CurrentDirectory}");
                        }
                        break;
                    case "3":
                        {
                            consoleText = consoleText.Replace(" ", ";");
                            wf.WriteToFile(consoleText, "json");
                            Console.WriteLine($"Файл сохранен в формате .json + {Environment.CurrentDirectory}");
                        }
                        break;
                }

                Console.Read();
            }


            interface IWrite
            {
                void WriteToFile(string text, string type);
            }

            class WriteFile : IWrite
            {
                public void WriteToFile(string text, string type)
                {
                    using (StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + @"\Console." + type, false, Encoding.GetEncoding("utf-8")))
                    {
                        sw.WriteLine(text);
                    }
                }
            }

        }
    }
}

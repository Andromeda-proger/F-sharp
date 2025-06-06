using System;
using System.IO;

namespace Компилятор
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Работает Pascal-компилятор\n");

            InputOutput.Init("test.txt");
            
            string outputFilePath = "output.txt";
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                LexicalAnalyzer lexer = new LexicalAnalyzer();
                bool firstToken = true;

                while (InputOutput.Ch != '\0')
                {
                    byte sym = lexer.NextSym();
                    
                    if (!firstToken)
                    {
                        writer.Write(" ");
                    }
                    writer.Write(sym);
                    firstToken = false;
                }
                
            }
            
            string fileContent = File.ReadAllText(outputFilePath);
            Console.WriteLine("\nСодержимое файла:");
            Console.WriteLine(fileContent);
        }
    }
}
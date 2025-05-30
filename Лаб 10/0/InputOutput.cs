using System;
using System.Collections.Generic;
using System.IO;

namespace Компилятор
{
    struct TextPosition
    {
        public uint lineNumber; // номер строки
        public byte charNumber; // номер позиции в строке

        public TextPosition(uint ln = 0, byte c = 0)
        {
            lineNumber = ln;
            charNumber = c;
        }
    }

    struct Err
    {
        public TextPosition errorPosition;
        public byte errorCode;

        public Err(TextPosition errorPosition, byte errorCode)
        {
            this.errorPosition = errorPosition;
            this.errorCode = errorCode;
        }
    }

    class InputOutput
    {
        const byte ERRMAX = 9;
        public static char Ch { get; private set; }
        public static TextPosition positionNow = new TextPosition();
        static string line = "";
        static byte lastInLine = 0;
        public static List<Err> err = new List<Err>();
        static bool isEmptyFile = false;
        static StreamReader File { get; set; }
        static uint errCount = 0;

        static Dictionary<byte, string> errorTable = new Dictionary<byte, string>()
        {
            {100, "использование имени не соответствует описанию"},
            {147, "тип метки не совпадает с типом выбирающего выражения"},
        };

        public static void Init(string filename)
        {
            File = new StreamReader(filename, System.Text.Encoding.UTF8);
            if (File.Peek() == -1)
            {
                isEmptyFile = true;
                line = "";
                Ch = '\0';
                End();
            }
            positionNow = new TextPosition(0, 0);
            errCount = 0;
            err = new List<Err>();



            ReadNextLine();
            positionNow.lineNumber = 1;
            positionNow.charNumber = 0;
            if (line.Length > 0)
                Ch = line[0];
            else
                Ch = '\0';
        }

        public static void NextCh()
        {
            if (positionNow.charNumber == lastInLine)
            {
                ListThisLine();
                if (err.Count > 0)
                    ListErrors();
                ReadNextLine();

                if (line == null)
                {
                    End();
                    Ch = '\0';
                }

                positionNow.lineNumber++;
                positionNow.charNumber = 0;
            }
            else
            {
                positionNow.charNumber++;
                Ch = line[positionNow.charNumber];
            }
        }

        private static void ListThisLine()
        {
            Console.WriteLine($"{positionNow.lineNumber} {line}");
        }

        private static void ReadNextLine()
        {
            if (!File.EndOfStream)
            {
                line = File.ReadLine();
                err = new List<Err>();

            }
            else
            {
                line = null;
            }
        }

        static void End()
        {
            Console.WriteLine($"Компиляция окончена: ошибок - {errCount} !");
            File.Close();
            Environment.Exit(0);
        }

        static void ListErrors()
        {
            int pos = 6 - $"{positionNow.lineNumber} ".Length;
            string s;
            foreach (Err item in err)
            {
                ++errCount;
                s = "**";
                if (errCount < 10) s += "0";
                s += $"{errCount}**";
                while (s.Length - 1 < pos + item.errorPosition.charNumber) s += " ";
                s += $"^ ошибка код {item.errorCode}";
                Console.WriteLine(s);

                if (errorTable.ContainsKey(item.errorCode))
                    Console.WriteLine(errorTable[item.errorCode]);
                else
                    Console.WriteLine("неизвестная ошибка");
                Console.WriteLine("******");
            }
        }

        public static void Error(byte errorCode, TextPosition position)
        {
            if (err.Count <= ERRMAX)
            {
                err.Add(new Err(position, errorCode));
            }
        }
    }
}

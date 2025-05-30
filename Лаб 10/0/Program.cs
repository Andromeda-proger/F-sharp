using System;

namespace Компилятор
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine("Работает Pascal-компилятор\n");

            InputOutput.Init("test.txt");

            while (InputOutput.Ch != '\0')
            {
                if (InputOutput.positionNow.lineNumber == 10 && InputOutput.positionNow.charNumber == 0)
                    InputOutput.Error(100, new TextPosition(InputOutput.positionNow.lineNumber, InputOutput.positionNow.charNumber));
                if (InputOutput.positionNow.lineNumber == 12 && InputOutput.positionNow.charNumber == 0)
                    InputOutput.Error(100, new TextPosition(InputOutput.positionNow.lineNumber, InputOutput.positionNow.charNumber));
                if (InputOutput.positionNow.lineNumber == 13 && InputOutput.positionNow.charNumber == 0)
                    InputOutput.Error(147, new TextPosition(InputOutput.positionNow.lineNumber, InputOutput.positionNow.charNumber));
                if (InputOutput.positionNow.lineNumber == 14 && InputOutput.positionNow.charNumber == 0)
                    InputOutput.Error(147, new TextPosition(InputOutput.positionNow.lineNumber, InputOutput.positionNow.charNumber));
                if (InputOutput.positionNow.lineNumber == 16 && InputOutput.positionNow.charNumber == 0)
                    InputOutput.Error(121, new TextPosition(InputOutput.positionNow.lineNumber, InputOutput.positionNow.charNumber));

                InputOutput.NextCh();
            }
        }
    }
}
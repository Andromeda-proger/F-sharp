using System;

namespace Компилятор
{
    class LexicalAnalyzer
    {
        public const byte
            
            star = 21, // *
            slash = 60, // /
            equal = 16, // =
            comma = 20, // ,
            semicolon = 14, // ;
            colon = 5, // :
            point = 61,	// .
            arrow = 62,	// ^
            leftpar = 9,	// (
            rightpar = 4,	// )
            lbracket = 11,	// [
            rbracket = 12,	// ]
            flpar = 63,	// {
            frpar = 64,	// }
            later = 65,	// <
            greater = 66,	// >
            laterequal = 67,	//  <=
            greaterequal = 68,	//  >=
            latergreater = 69,	//  <>
            plus = 70,	// +
            minus = 71,	// –
            lcomment = 72,	//  (*
            rcomment = 73,	//  *)
            assign = 51,	//  :=
            twopoints = 74,	//  ..
            cowichka=99,
            ident = 2,	// идентификатор
            floatc = 82,	// вещественная константа
            intc = 15,	// целая константа
            casesy = 31,
            elsesy = 32,
            filesy = 57,
            gotosy = 33,
            thensy = 52,
            typesy = 34,
            untilsy = 53,
            dosy = 54,
            withsy = 37,
            ifsy = 56,
            insy = 100,
            ofsy = 101,
            orsy = 102,
            tosy = 103,
            endsy = 104,
            varsy = 105,
            divsy = 106,
            andsy = 107,
            notsy = 108,
            forsy = 109,
            modsy = 110,
            nilsy = 111,
            setsy = 112,
            beginsy = 113,
            whilesy = 114,
            arraysy = 115,
            constsy = 116,
            labelsy = 117,
            downtosy = 118,
            packedsy = 119,
            recordsy = 120,
            repeatsy = 121,
            programsy = 122,
            functionsy = 123,
            procedurensy = 124,
            readsy = 125,   
            realsy = 126, 
            exitsy = 127,  
            writesy = 128,   
            writelnsy = 129, 
            stringsy = 130,  
            booleansy = 131,  
            integersy = 132,  
            readlnsy = 133,
            unknown = 255;

        byte symbol; 
        TextPosition token;
        string addrName; 
        int nmb_int; 
        float nmb_float; 
        char one_symbol; 

        private Keywords keywords = new Keywords();

        public byte NextSym()
        {
            while (InputOutput.Ch == ' ' || InputOutput.Ch == '\t') InputOutput.NextCh();
            token.lineNumber = InputOutput.positionNow.lineNumber;
            token.charNumber = InputOutput.positionNow.charNumber;
            
            switch (InputOutput.Ch)
            {
                case char ch when (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z'):
                    ScanIdentifierOrKeyword();
                    break;

                case char ch when ch >= '0' && ch <= '9':
                    ScanNumber();
                    break;

                case '\'':
                    symbol = cowichka;
                    InputOutput.NextCh();
                    break;

                case '<':
                    InputOutput.NextCh();
                    if (InputOutput.Ch == '=')
                    {
                        symbol = laterequal; InputOutput.NextCh();
                    }
                    else if (InputOutput.Ch == '>')
                    {
                        symbol = latergreater; InputOutput.NextCh();
                    }
                    else
                        symbol = later;
                    break;

                case ':':
                    InputOutput.NextCh();
                    if (InputOutput.Ch == '=')
                    {
                        symbol = assign; InputOutput.NextCh();
                    }
                    else
                        symbol = colon;
                    break;

                case ';':
                    symbol = semicolon;
                    InputOutput.NextCh();
                    break;

                case '.':
                    InputOutput.NextCh();
                    if (InputOutput.Ch == '.')
                    {
                        symbol = twopoints; InputOutput.NextCh();
                    }
                    else symbol = point;
                    break;

                case '(':
                    InputOutput.NextCh();
                    if (InputOutput.Ch == '*')
                    {
                        symbol = lcomment; InputOutput.NextCh();
                        
                    }
                    else
                    {
                        symbol = leftpar;
                    }
                    break;

                case ')':
                    symbol = rightpar;
                    InputOutput.NextCh();
                    break;

                case '[':
                    symbol = lbracket;
                    InputOutput.NextCh();
                    break;

                case ']':
                    symbol = rbracket;
                    InputOutput.NextCh();
                    break;

                case '{':
                    symbol = flpar;
                    InputOutput.NextCh();
                    break;

                case '}':
                    symbol = frpar;
                    InputOutput.NextCh();
                    break;

                case '>':
                    InputOutput.NextCh();
                    if (InputOutput.Ch == '=')
                    {
                        symbol = greaterequal; InputOutput.NextCh();
                    }
                    else
                        symbol = greater;
                    break;

                case '=':
                    symbol = equal;
                    InputOutput.NextCh();
                    break;

                case ',':
                    symbol = comma;
                    InputOutput.NextCh();
                    break;

                case '+':
                    symbol = plus;
                    InputOutput.NextCh();
                    break;

                case '-':
                    symbol = minus;
                    InputOutput.NextCh();
                    break;

                case '*':
                    symbol = star;
                    InputOutput.NextCh();
                    break;

                case '/':
                    symbol = slash;
                    InputOutput.NextCh();
                    break;

                case '^':
                    symbol = arrow;
                    InputOutput.NextCh();
                    break;

                case '\0':
                    symbol = 0;
                    break;

                default:
                    InputOutput.Error(200, InputOutput.positionNow);
                    symbol = unknown;
                    InputOutput.NextCh();
                    break;
            }

            return symbol;
        }

        private void ScanIdentifierOrKeyword()
        {
            string name = "";
            while ((InputOutput.Ch >= 'a' && InputOutput.Ch <= 'z') ||
                  (InputOutput.Ch >= 'A' && InputOutput.Ch <= 'Z') ||
                  (InputOutput.Ch >= '0' && InputOutput.Ch <= '9'))
            {
                name += InputOutput.Ch;
                InputOutput.NextCh();
            }
            
            byte length = (byte)name.Length;
            if (keywords.Kw.ContainsKey(length) && keywords.Kw[length].ContainsKey(name.ToLower()))
            {
                symbol = keywords.Kw[length][name.ToLower()];
            }
            else
            {
                symbol = ident;
                addrName = name; 
            }
        }

        private void ScanNumber()
        {
            byte digit;
            Int16 maxint = Int16.MaxValue;
            nmb_int = 0;
            bool isFloat = false;
            
            while (InputOutput.Ch >= '0' && InputOutput.Ch <= '9')
            {
                digit = (byte)(InputOutput.Ch - '0');
                if (nmb_int < maxint / 10 ||
                    (nmb_int == maxint / 10 &&
                     digit <= maxint % 10))
                {
                    nmb_int = 10 * nmb_int + digit;
                }
                else
                {
                    InputOutput.Error(203, InputOutput.positionNow);
                    nmb_int = 0;
                    while (InputOutput.Ch >= '0' && InputOutput.Ch <= '9') InputOutput.NextCh();
                    break;
                }
                InputOutput.NextCh();
            }
            
            if (InputOutput.Ch == '.')
            {
                InputOutput.NextCh();
                if (InputOutput.Ch >= '0' && InputOutput.Ch <= '9')
                {
                    isFloat = true;
                    nmb_float = nmb_int;
                    float fraction = 0.1f;

                    while (InputOutput.Ch >= '0' && InputOutput.Ch <= '9')
                    {
                        nmb_float += (InputOutput.Ch - '0') * fraction;
                        fraction *= 0.1f;
                        InputOutput.NextCh();
                    }
                    
                    if (InputOutput.Ch == 'e' || InputOutput.Ch == 'E')
                    {
                        InputOutput.NextCh();
                        int exponent = 0;
                        bool negativeExponent = false;

                        if (InputOutput.Ch == '+')
                        {
                            InputOutput.NextCh();
                        }
                        else if (InputOutput.Ch == '-')
                        {
                            negativeExponent = true;
                            InputOutput.NextCh();
                        }

                        while (InputOutput.Ch >= '0' && InputOutput.Ch <= '9')
                        {
                            exponent = 10 * exponent + (InputOutput.Ch - '0');
                            InputOutput.NextCh();
                        }

                        if (negativeExponent)
                        {
                            exponent = -exponent;
                        }

                        nmb_float *= (float)Math.Pow(10, exponent);
                    }

                    symbol = floatc;
                    return;
                }
                else
                {
                    symbol = point;
                    return;
                }
            }

            if (!isFloat)
            {
                symbol = intc;
            }
        }
        
    }
}
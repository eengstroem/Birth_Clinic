using System;
using System.Threading;
using Library.Display;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Display Disp = new();

            while (true)
            {
                
                Char Input = Disp.ReadSingleCharFromDisplay();

                switch (Input)
                {
                    case 'A':
                        Console.WriteLine("case 1");

                        Disp.Reset();
                        


                        break;
                    case 'B':
                        Console.WriteLine("case 2");
                        Disp.Reset();
                        break;
                    case 'C':
                        Console.WriteLine("case 3");
                        Disp.Reset();
                        break;
                    case 'D':
                        Console.WriteLine("case 4");
                        Disp.Reset();
                        break;
                    case 'E':

                        Console.WriteLine("1: Given a birth is planned: Show the rooms reserved the birth");
                        Console.WriteLine("2: Given a birth is planned: Show the clinicians assigned the birth");
                        int Choice = Disp.ReadAndParseInt32FromDisplay();
                        switch (Choice)
                        {
                            case 1:
                                Console.WriteLine("case 5");

                                break;
                            case 2:
                                Console.WriteLine("case 6");

                                break;
                            default:
                                Console.WriteLine("Unacceptable input");
                                Thread.Sleep(1000);
                                Disp.ForceReset();
                                break;
                        }
                        break;

                    default:
                        Console.WriteLine("Unacceptable input");
                        Thread.Sleep(1000);
                        Disp.ForceReset();
                        break;
                }
            }


            }
    }
}

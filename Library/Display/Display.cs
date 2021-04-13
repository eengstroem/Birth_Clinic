using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Library.Display
{
    public class Display
    {

        public Display()
        {
            Console.WriteLine("Loading.");
            Console.Beep(660, 100);
            Thread.Sleep(150);
            Console.SetCursorPosition(0, 0);
            ClearCurrentConsoleLine();
            Console.WriteLine("Loading..");
            Console.Beep(660, 100);
            Thread.Sleep(300);
            Console.SetCursorPosition(0, 0);
            ClearCurrentConsoleLine();
            Console.WriteLine("Loading...");
            Console.Beep(660, 100);
            Thread.Sleep(300);
            Console.SetCursorPosition(0, 0);
            ClearCurrentConsoleLine();
            Console.WriteLine("Loading..");
            Console.Beep(510, 100);
            Thread.Sleep(100);
            Console.SetCursorPosition(0, 0);
            ClearCurrentConsoleLine();
            Console.WriteLine("Loading.");
            Console.Beep(660, 100);
            Thread.Sleep(300);
            Console.SetCursorPosition(0, 0);
            ClearCurrentConsoleLine();
            Console.WriteLine("Loading..");
            Console.Beep(770, 100);
            Thread.Sleep(550);
            Console.SetCursorPosition(0, 0);
            ClearCurrentConsoleLine();
            Console.WriteLine("Loading...");
            Console.Beep(380, 100);
            Thread.Sleep(575);
            Console.SetCursorPosition(0, 0);
            ClearCurrentConsoleLine();

            Console.WriteLine("Hello, please type the corresponding letter to choose one of the following options:");
            Console.WriteLine("A: Show planned births for the coming three days");
            Console.WriteLine("B: Show clinicians, birth rooms, maternity rooms and rest rooms available at the clinic for the next five days");
            Console.WriteLine("C: Show the current ongoing births with information about the birth, parents, clinicians associated and the birth room.");
            Console.WriteLine("D: Show the maternity rooms and the rest rooms in use with the parent(s) and child(ren) using the room.");
            Console.WriteLine("E: Specific information about a specific planned birth");
        }

        public void Reset()
        {
            Console.WriteLine("Once you are finished reading big data, press esc to return to main menu.");

            ConsoleKey line = Console.ReadKey().Key;
            while (line != ConsoleKey.Escape) {
                line = Console.ReadKey().Key;
            }
            Console.Clear();
            Console.Write("A");
            Console.WriteLine("Hello, please type the corresponding letter to choose one of the following options:");
            Console.WriteLine("A: Show planned births for the coming three days");
            Console.WriteLine("B: Show clinicians, birth rooms, maternity rooms and rest rooms available at the clinic for the next five days");
            Console.WriteLine("C: Show the current ongoing births with information about the birth, parents, clinicians associated and the birth room.");
            Console.WriteLine("D: Show the maternity rooms and the rest rooms in use with the parent(s) and child(ren) using the room.");
            Console.WriteLine("E: Specific information about a specific planned birth");
            
        }

        public void ForceReset(string errorMessage)
        {
            Console.Clear();
            Console.WriteLine(errorMessage);
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Hello, please type the corresponding letter to choose one of the following options:");
            Console.WriteLine("A: Show planned births for the coming three days");
            Console.WriteLine("B: Show clinicians, birth rooms, maternity rooms and rest rooms available at the clinic for the next five days");
            Console.WriteLine("C: Show the current ongoing births with information about the birth, parents, clinicians associated and the birth room.");
            Console.WriteLine("D: Show the maternity rooms and the rest rooms in use with the parent(s) and child(ren) using the room.");
            Console.WriteLine("E: Specific information about a specific planned birth");

        }
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public int ReadAndParseInt32FromDisplay()
        {
            string line = "";
            int Choice = -1;
            while (Choice == -1)
            {
                try
                {
                    line = Console.ReadLine();
                    Choice = Int32.Parse(line);
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} is not a valid integer!\nTry again:", line);
                    Choice = -1;

                }
            }
            return Choice;
        }
        public char ReadSingleCharFromDisplay()
        {
            char line = ' ';
            while (line == ' ')
            {
                try
                {
                    line = Console.ReadLine().ToString().ToUpper()[0];
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Unacceptable input!\nTry again:");
                    line = ' ';

                }
            }
            return line;
        }
    }
}

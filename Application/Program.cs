using System;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, please type the corresponding letter to choose one of the following options:");
            Console.WriteLine("A: Show planned births for the coming three days");
            Console.WriteLine("B: Show clinicians, birth rooms, maternity rooms and rest rooms available at the clinic for the next five days");
            Console.WriteLine("C: Show the current ongoing births with information about the birth, parents, clinicians associated and the birth room.");
            Console.WriteLine("D: Show the maternity rooms and the rest rooms in use with the parent(s) and child(ren) using the room.");
            Console.WriteLine("E: Specific information about a specific planned birth");

            Char Input = Console.ReadLine().ToString().ToUpper()[0];

            switch (Input)
            {
                case 'A':
                    Console.WriteLine("case 1");
                    break;
                case 'B':
                    Console.WriteLine("case 2");
                    break;
                case 'C':
                    Console.WriteLine("case 3");
                    break;
                case 'D':
                    Console.WriteLine("case 4");
                    break;
                case 'E':

                    Console.WriteLine("1: Given a birth is planned: Show the rooms reserved the birth");
                    Console.WriteLine("2: Given a birth is planned: Show the clinicians assigned the birth"); 
                    int Choice = Int32.Parse(Console.ReadLine());

                    switch (Choice)
                    {
                        case 1:
                            Console.WriteLine("case 5");

                            break;
                        case 2:
                            Console.WriteLine("case 6");

                            break;
                    }
                    break;
            }


        }
    }
}

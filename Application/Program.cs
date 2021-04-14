using Library.Context;
using Library.DataGenerator;
using Library.Display;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection Services = new();

            ConfigureServices(Services);

            ServiceProvider ServiceProvider = Services.BuildServiceProvider();
            var Context = ServiceProvider.GetService<BirthClinicDbContext>();
            DataGenerator.GenerateStaticData(Context);
            DataGenerator.GenerateData(Context);

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
                                Disp.Reset();
                                break;
                            case 2:
                                Console.WriteLine("case 6");
                                Disp.Reset();
                                break;
                            default:
                                Disp.ForceReset("Unacceptable input");
                                break;
                        }
                        break;
                    case 'M':
                        Disp.marioFunny();
                        Disp.ForceReset("");
                        break;
                    default:
                        Disp.ForceReset("Unacceptable input");
                        break;
                }
            }


        }

        public static void ConfigureServices(ServiceCollection SC)
        {
            SC.AddDbContext<BirthClinicDbContext>(options =>
            {
                var dataSource = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DebtBook.db");
                options.UseSqlServer("server=localhost,1433; User Id=sa; Password=password_123; database=myDb; trusted_connection=false;");
        });
        }
    }
}

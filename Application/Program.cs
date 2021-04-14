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
                        Disp.Case1(Context);
                        Disp.Reset();
                        


                        break;
                    case 'B':
                        Disp.Case2(Context);
                        Disp.Reset();
                        break;
                    case 'C':
                        Disp.Case3(Context);
                        Disp.Reset();
                        break;
                    case 'D':
                        Disp.Case4(Context);
                        Disp.Reset();
                        break;
                    case 'E':

                        Disp.Case5(Context);
                        Disp.Reset();
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
                options.UseSqlServer("server=[::1],1433; User Id=SA; Password=password_123; database=myDb; trusted_connection=false;");
        });
        }
    }
}

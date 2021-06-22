using System;

namespace Week6.GestioneAutomobili
{
    class Program
    {


        static void Main(string[] args)
        {
            using (var ctx = new CarsManagementContext())
            {
                ctx.Database.EnsureCreated();

                foreach(var car in ctx.Cars)
                {

                    Console.WriteLine(car);
                }

                foreach(var person in ctx.People)
                {
                    Console.WriteLine(person);
                }
            }
        }
    }
}

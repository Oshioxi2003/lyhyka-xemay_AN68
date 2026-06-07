using System;
using System.Linq;

namespace EF6_SQLite_Working_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MyDbContext())
            {
                Console.WriteLine("Checking Events table...");

                var count = db.Events.Count();
                Console.WriteLine($"Event count: {count}");

                db.Events.Add(new Event { EventName = "New Event from Clean Setup" });
                db.SaveChanges();

                Console.WriteLine("New event added. Current Events:");
                foreach (var ev in db.Events)
                {
                    Console.WriteLine($"Id={ev.Id}, Name={ev.EventName}");
                }
            }

            Console.WriteLine("All done. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
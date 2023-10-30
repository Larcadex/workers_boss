using System;

namespace workers
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            string[] offices = { "Офис А", "Офис Б" };
            
            foreach (var office in offices)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine($"Информация о офисе {office}:");
                Console.WriteLine("--------------------------------------------");

                List<Worker> workers = new List<Worker>();

                for (int i = 1; i <= 5; i++)
                {   Console.WriteLine(); 
                    Worker worker = new Worker($"Работник {i}", rnd.Next(16, 51), office);
                    workers.Add(worker);
                    worker.get_info();
                    
                }
                Console.WriteLine("\n--------------------------------------------");
                Boss boss = new Boss($"Босс {office}", 50, office, workers);
                boss.get_info();
                Console.WriteLine("--------------------------------------------\n");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace workers
{
    class Worker : Human
    {
        protected string office;
        protected int[] shifts;
        protected int day_shifts_count;
        protected int night_shifts_count;
        protected int salary;
        protected const int day_shifts_rate = 1000;
        protected const int night_shifts_rate = 1500;
        
        public Worker(string name, int age, string office) : base(name, age)
        {
            this.office = office;
            shifts = new int[30];
            generate_shifts();
            set_shifts_type();
        }

        private void generate_shifts()
        {
            Random random = new Random();
            if (age > 18)
            {   
                for (int i = 0; i < 30; i++)
                {
                    shifts[i] = random.Next(1, 3);
                }
            }
            else
            {
                for (int i = 0; i < 30; i++)
                {
                    shifts[i] = 1;
                }
            }
        }

        private void set_shifts_type()
        {
            day_shifts_count = shifts.Count(shifts => shifts == 1);
            night_shifts_count = shifts.Count(shifts => shifts == 2);
            
            salary = (night_shifts_count * night_shifts_rate) + (day_shifts_count * day_shifts_rate);
        }
        
        public int get_day_shifts()
        {
            return day_shifts_count;
        }

        public int get_night_shifts()
        {
            return night_shifts_count;
        }
        

        public virtual void get_info()
        {
            Console.WriteLine($"Имя: {name}, Возраст: {age}, Офис: {office}, Дневные смены: {day_shifts_count}, Ночные смены: {night_shifts_count}, Зарплата: {salary}");
        }
    }
}

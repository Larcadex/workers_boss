using System;

namespace workers
{
    class Boss : Worker
    {
        private List<Worker> workers;
        private const int mandatory_shifts = 60; //норма смен
        private int total_day_shifts;
        private int total_night_shifts;
        private int extra_day_shifts;
        private int extra_night_shifts;
        private int day_salary;
        private int night_salary;
        private int extra_day_salary;
        private int extra_night_salary;
        
        public Boss(string name, int age, string office, List<Worker> workers) : base(name, age, office)
        {
            this.workers = workers;
            сalculate();
        }

        private void сalculate()
        {
            total_day_shifts = workers.Sum(worker => worker.get_day_shifts());
            total_night_shifts = workers.Sum(worker => worker.get_night_shifts());
            
            extra_day_shifts = total_day_shifts - mandatory_shifts;
            extra_night_shifts = total_night_shifts - mandatory_shifts;
            
            day_salary = total_day_shifts * day_shifts_rate;
            night_salary = total_night_shifts * night_shifts_rate;

            extra_day_salary = (int)(extra_day_shifts * (day_shifts_rate + day_shifts_rate * 0.1));  // 10% за дневные
            extra_night_salary = (int)(extra_night_shifts * (night_shifts_rate + night_shifts_rate * 0.15)); // 15% за ночные
            
        }
        
        public override void get_info()
        {
            Console.WriteLine($"Имя: {name}, Офис: {office}, " +
                              $"\nВсего дневных смен: {total_day_shifts}, Всего ночных смен: {total_night_shifts}, " +
                              $"\nДневные переработки: {extra_day_shifts}, Ночные переработки: {extra_night_shifts}, " +
                              $"\nЗарплата за дневные смены: {day_salary}, Зарплата за ночные смены: {night_salary}, " +
                              $"\nПлата за дневные переработки: {extra_day_salary}, Плата за ночные переработки: {extra_night_salary}," +
                              $"\nОбщая зарплата без учета переработок: {day_salary + night_salary}, Общая зарплата за переработки: {extra_day_salary + extra_night_salary}:" +
                              $"\nОбщая сумма заработка: {day_salary + night_salary + extra_day_salary + extra_night_salary}");
        }
    }
}
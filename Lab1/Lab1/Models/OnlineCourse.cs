using System;
using System.Collections.Generic;

namespace CourseManagement.Models
{
    public class OnlineCourse : Course
    {
        public string URL { get; set; }

        // конструктор 
        public OnlineCourse(string title, string url) : base(title)
        {
            URL = url;
        }

        // переопределение абстрактного метода для вывода информации о курсе
        public override void DisplayInfo()
        {
            Console.WriteLine($"Онлайн-курс: {Title}");
            Console.WriteLine($"URL: {URL}");
            Console.WriteLine($"Преподаватель: {AssignedTeacher?.Name ?? "Не назначен"}");
            Console.WriteLine("Студенты на курсе:");
            if (Students.Count == 0)
                Console.WriteLine(" - Отсутствуют");
            else
            {
                foreach (var s in Students)
                {
                    Console.WriteLine($" - {s.Name}");
                }
            }
            Console.WriteLine();
        }
    }
}

using System;
using System.Collections.Generic;

namespace CourseManagement.Models
{
    public class OfflineCourse : Course
    {
        public string Location { get; set; }

        public OfflineCourse(string title, string location) : base(title)
        {
            Location = location;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Офлайн-курс: {Title}");
            Console.WriteLine($"Место проведения: {Location}");
            Console.WriteLine($"Преподаватель: {AssignedTeacher?.Name ?? "Не назначен"}");
            Console.WriteLine("Студенты на курсе:");
            if (Students.Count == 0)
            {
                Console.WriteLine(" - Отсутствуют");
            }
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

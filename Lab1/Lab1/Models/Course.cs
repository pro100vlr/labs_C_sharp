using System;
using System.Collections.Generic;

namespace CourseManagement.Models
{
    public abstract class Course
    {
        public string Title { get; set; }

        // список студентов, записанных на курс
        public List<Student> Students { get; private set; } = new List<Student>();

        // назначенный преподаватель
        public Teacher AssignedTeacher { get; set; }

        protected Course(string title)
        {
            Title = title;
        }

        public void AddStudent(Student student)
        {
            if (!Students.Contains(student))
            {
                Students.Add(student);
            }
        }

        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
        }

        // Абстрактный метод для вывода информации о курсе (переопределяется в наследниках)
        public abstract void DisplayInfo();
    }
}

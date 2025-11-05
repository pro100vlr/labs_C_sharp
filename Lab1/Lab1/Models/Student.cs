using System;

namespace CourseManagement.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // конструктор с id и именем
        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // переопределённый метод ToString для удобного вывода информации
        public override string ToString()
        {
            return $"Студент: {Name} (ID: {Id})";
        }
    }
}

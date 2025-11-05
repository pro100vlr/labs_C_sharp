using System;

namespace CourseManagement.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // конструктор с id и именем преподавателя
        public Teacher(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // переопределённый метод ToString для удобного вывода
        public override string ToString()
        {
            return $"Преподаватель: {Name} (ID: {Id})";
        }
    }
}

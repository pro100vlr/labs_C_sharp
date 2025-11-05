using System;
using System.Collections.Generic;
using CourseManagement.Models;

namespace CourseManagement.Services
{
    public class CourseManager
    {
        private List<Course> courses = new List<Course>();
        private List<Teacher> teachers = new List<Teacher>();
        private List<Student> students = new List<Student>();

        public void AddCourse(Course course)
        {
            if (course != null)
            {
                courses.Add(course);
                // Console.WriteLine($"Курс '{course.Title}' добавлен.");
            }
        }

        public void RemoveCourseAt(int index)
        {
            if (index >= 0 && index < courses.Count)
            {
                Console.WriteLine($"Курс '{courses[index].Title}' удалён.");
                courses.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Некорректный индекс курса.");
            }
        }

        public List<Course> GetAllCourses()
        {
            return new List<Course>(courses);
        }

        public void AddTeacher(Teacher teacher)
        {
            if (teacher != null)
            {
                teachers.Add(teacher);
                // Console.WriteLine($"Преподаватель '{teacher.Name}' добавлен.");
            }
        }

        public List<Teacher> GetAllTeachers()
        {
            return new List<Teacher>(teachers);
        }

        public void AddStudent(Student student)
        {
            if (student != null)
            {
                students.Add(student);
                // Console.WriteLine($"Студент '{student.Name}' добавлен.");
            }
        }

        public List<Student> GetAllStudents()
        {
            return new List<Student>(students);
        }

        public void AssignTeacherToCourse(int courseIndex, int teacherIndex)
        {
            if (courseIndex < 0 || courseIndex >= courses.Count)
            {
                Console.WriteLine("Некорректный индекс курса.");
                return;
            }

            if (teacherIndex < 0 || teacherIndex >= teachers.Count)
            {
                Console.WriteLine("Некорректный индекс преподавателя.");
                return;
            }

            courses[courseIndex].AssignedTeacher = teachers[teacherIndex];
            Console.WriteLine($"Преподаватель {teachers[teacherIndex].Name} назначен на курс {courses[courseIndex].Title}.");
        }

        public void AddStudentToCourse(int courseIndex, Student student)
        {
            if (courseIndex < 0 || courseIndex >= courses.Count)
            {
                Console.WriteLine("Некорректный индекс курса.");
                return;
            }

            if (student == null)
            {
                Console.WriteLine("Студент не найден.");
                return;
            }

            courses[courseIndex].AddStudent(student);
            Console.WriteLine($"Студент {student.Name} добавлен на курс {courses[courseIndex].Title}.");
        }

        public List<Course> GetCoursesByTeacher(Teacher teacher)
        {
            List<Course> result = new List<Course>();
            if (teacher == null) return result;

            foreach (var course in courses)
            {
                if (course.AssignedTeacher != null && course.AssignedTeacher == teacher)
                {
                    result.Add(course);
                }
            }
            return result;
        }
    }
}

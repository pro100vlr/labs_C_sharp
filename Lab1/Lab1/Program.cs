using System;
using CourseManagement.Models; // подключаем папку моделс
using CourseManagement.Services;

namespace CourseManagement
{
    class Program
    {
        // класс-сервис, дает доступ во всех статических методов
        static CourseManager courseManager = new CourseManager();

        static void Main()
        {
            InitializeData(); // добавление начальных данных о курсах и преподавателях

            while (true) 
            {
                Console.WriteLine("Система управления курсами и преподавателями");
                Console.WriteLine("1. Показать все курсы");
                Console.WriteLine("2. Добавить курс");
                Console.WriteLine("3. Удалить курс");
                Console.WriteLine("4. Назначить преподавателя на курс");
                Console.WriteLine("5. Добавить студента на курс");
                Console.WriteLine("6. Показать курсы преподавателя");
                Console.WriteLine("7. Добавить преподавателя");
                Console.WriteLine("8. Добавить студента");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();

                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ShowAllCourses();
                        break;
                    case "2":
                        AddCourse();
                        break;
                    case "3":
                        RemoveCourse();
                        break;
                    case "4":
                        AssignTeacher();
                        break;
                    case "5":
                        AddStudentToCourse();
                        break;
                    case "6":
                        ShowCoursesByTeacher();
                        break;
                    case "7":
                        AddTeacher();
                        break;
                    case "8":
                        AddStudent();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
                Console.WriteLine();
            }
        }

        static void InitializeData() 
        {
            // Изначальные преподаватели
            courseManager.AddTeacher(new Teacher(1, "Иванов Иван Петрович"));
            courseManager.AddTeacher(new Teacher(2, "Петров Петр Игнатьевич"));
            courseManager.AddTeacher(new Teacher(2, "Синицкий Роман Владимирович"));

            // Изначальные студенты
            courseManager.AddStudent(new Student(1, "Петров Алексей"));
            courseManager.AddStudent(new Student(2, "Головина Мария"));

            // Изначальные курсы
            courseManager.AddCourse(new OnlineCourse("C# для начинающих", "http://onlinecourse.com/csharp"));
            courseManager.AddCourse(new OfflineCourse("Математика", "Аудитория 101"));
        }

        static void ShowAllCourses()
        {
            var courses = courseManager.GetAllCourses(); // получение списка курсов
            if (courses.Count == 0)
            {
                Console.WriteLine("Курсы отсутствуют.\n");
                return;
            }

            for (int i = 0; i < courses.Count; i++)
            {
                var course = courses[i];
                Console.WriteLine($"[{i + 1}]");
                course.DisplayInfo(); // метод вывода информации о курсе
                Console.WriteLine();
            }
        }

        static void AddCourse()
        {
            Console.Write("Введите название курса: ");
            string title = Console.ReadLine();

            Console.Write("Тип курса (1 - Онлайн, 2 - Офлайн): ");
            string type = Console.ReadLine();

            if (type == "1")
            {
                Console.Write("Введите URL онлайн-курса: ");
                string url = Console.ReadLine();
                courseManager.AddCourse(new OnlineCourse(title, url));
            }
            else if (type == "2")
            {
                Console.Write("Введите место проведения офлайн-курса: ");
                string location = Console.ReadLine();
                courseManager.AddCourse(new OfflineCourse(title, location));
            }
            else
            {
                Console.WriteLine("Неверный тип курса.");
            }
        }

        static void RemoveCourse()
        {
            ShowAllCourses();
            Console.Write("Введите индекс удаляемого курса: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                courseManager.RemoveCourseAt(index - 1);
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }
        }

        static void AssignTeacher() // назначение преподавателя
        {
            ShowAllCourses();

            Console.Write("Введите индекс курса: ");
            if (!int.TryParse(Console.ReadLine(), out int courseIndex))
            {
                Console.WriteLine("Некорректный ввод курса.");
                return;
            }

            var teachers = courseManager.GetAllTeachers();
            if (teachers.Count == 0)
            {
                Console.WriteLine("Преподаватели отсутствуют.");
                return;
            }

            Console.WriteLine("Преподаватели:");
            for (int i = 0; i < teachers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {teachers[i].Name}");
            }

            Console.Write("Введите индекс преподавателя: ");
            if (!int.TryParse(Console.ReadLine(), out int teacherIndex))
            {
                Console.WriteLine("Некорректный ввод преподавателя.");
                return;
            }

            courseManager.AssignTeacherToCourse(courseIndex - 1, teacherIndex - 1);
        }

        static void AddStudentToCourse()
        {
            ShowAllCourses();

            Console.Write("Введите индекс курса: ");
            if (!int.TryParse(Console.ReadLine(), out int courseIndex))
            {
                Console.WriteLine("Некорректный ввод курса.");
                return;
            }

            var students = courseManager.GetAllStudents();
            if (students.Count == 0)
            {
                Console.WriteLine("Студенты отсутствуют.");
                return;
            }

            Console.WriteLine("Студенты:");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {students[i].Name}");
            }

            Console.Write("Введите индекс студента: ");
            if (!int.TryParse(Console.ReadLine(), out int studentIndex))
            {
                Console.WriteLine("Некорректный ввод студента.");
                return;
            }

            courseManager.AddStudentToCourse(courseIndex - 1, students[studentIndex - 1]);
        }

        static void ShowCoursesByTeacher()
        {
            var teachers = courseManager.GetAllTeachers();
            if (teachers.Count == 0)
            {
                Console.WriteLine("Преподаватели отсутствуют.");
                return;
            }

            Console.WriteLine("Преподаватели:");
            for (int i = 0; i < teachers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {teachers[i].Name}");
            }

            Console.Write("Введите индекс преподавателя: ");
            if (!int.TryParse(Console.ReadLine(), out int teacherIndex))
            {
                Console.WriteLine("Некорректный ввод.");
                return;
            }

            var teacher = teachers[teacherIndex - 1];
            var courses = courseManager.GetCoursesByTeacher(teacher);
            Console.WriteLine($"Курсы преподавателя {teacher.Name}:");
            if (courses.Count == 0)
            {
                Console.WriteLine(" - Нет курсов");
            }
            else
            {
                foreach (var course in courses)
                {
                    Console.WriteLine($"- {course.Title}");
                }
            }
        }

        static void AddTeacher()
        {
            Console.Write("Введите имя преподавателя: ");
            string name = Console.ReadLine();
            int newId = courseManager.GetAllTeachers().Count + 1;
            var teacher = new Teacher(newId, name);
            courseManager.AddTeacher(teacher);
            Console.WriteLine($"Преподаватель '{teacher.Name}' добавлен с ID: {teacher.Id}");
        }

        static void AddStudent()
        {
            Console.Write("Введите имя студента: ");
            string name = Console.ReadLine();
            int newId = courseManager.GetAllStudents().Count + 1;
            var student = new Student(newId, name);
            courseManager.AddStudent(student);
            Console.WriteLine($"Студент '{student.Name}' добавлен с ID: {student.Id}");
        }
    }
}

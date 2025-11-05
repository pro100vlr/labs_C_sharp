using Xunit;
using CourseManagement.Models;
using CourseManagement.Services;
using System.Linq;

namespace CourseManagement.Tests
{
    public class CourseManagerTests
    {
        [Fact]
        public void AddCourse_ShouldAddCourseWithCorrectProperties()
        {
            var manager = new CourseManager();
            var course = new OnlineCourse("C#", "http://url");

            manager.AddCourse(course);

            var allCourses = manager.GetAllCourses();
            Assert.Single(allCourses);
            Assert.Equal("C#", allCourses[0].Title);
            Assert.Equal("http://url", ((OnlineCourse)allCourses[0]).URL);
        }

        [Fact]
        public void RemoveCourseAt_ShouldRemoveCourse()
        {
            var manager = new CourseManager();
            var course = new OfflineCourse("Math", "Room 101");
            manager.AddCourse(course);

            manager.RemoveCourseAt(0);

            Assert.Empty(manager.GetAllCourses());
        }

        [Fact]
        public void RemoveCourseAt_InvalidIndex_ShouldNotThrow()
        {
            var manager = new CourseManager();
            manager.RemoveCourseAt(0); // Список пустой
            Assert.Empty(manager.GetAllCourses());
        }

        [Fact]
        public void AddTeacher_ShouldAddTeacher()
        {
            var manager = new CourseManager();
            var teacher = new Teacher(1, "John");

            manager.AddTeacher(teacher);

            var allTeachers = manager.GetAllTeachers();
            Assert.Single(allTeachers);
            Assert.Equal("John", allTeachers[0].Name);
        }

        [Fact]
        public void AssignTeacherToCourse_ShouldSetTeacher()
        {
            var manager = new CourseManager();
            var course = new OnlineCourse("C#", "http://url");
            var teacher = new Teacher(1, "John");

            manager.AddCourse(course);
            manager.AddTeacher(teacher);
            manager.AssignTeacherToCourse(0, 0);

            Assert.Equal(teacher, manager.GetAllCourses()[0].AssignedTeacher);
        }

        [Fact]
        public void AssignTeacherToCourse_InvalidIndices_ShouldNotThrow()
        {
            var manager = new CourseManager();
            var course = new OnlineCourse("C#", "http://url");
            manager.AddCourse(course);

            // Некорректный индекс курса
            manager.AssignTeacherToCourse(1, 0);

            // Некорректный индекс преподавателя
            var teacher = new Teacher(1, "John");
            manager.AddTeacher(teacher);
            manager.AssignTeacherToCourse(0, 1);

            Assert.Null(manager.GetAllCourses()[0].AssignedTeacher);
        }

        [Fact]
        public void AddStudentToCourse_ShouldAddStudent()
        {
            var manager = new CourseManager();
            var student = new Student(1, "Alice");
            var course = new OfflineCourse("Math", "Room 101");

            manager.AddCourse(course);
            manager.AddStudent(student);
            manager.AddStudentToCourse(0, student);

            Assert.Contains(student, manager.GetAllCourses()[0].Students);
        }

        [Fact]
        public void AddStudentToCourse_InvalidIndex_ShouldNotThrow()
        {
            var manager = new CourseManager();
            var student = new Student(1, "Alice");
            manager.AddStudent(student);

            // Нет курсов
            manager.AddStudentToCourse(0, student);
        }

        [Fact]
        public void GetCoursesByTeacher_ShouldReturnCorrectCourses()
        {
            var manager = new CourseManager();
            var teacher1 = new Teacher(1, "John");
            var teacher2 = new Teacher(2, "Mary");

            var course1 = new OnlineCourse("C#", "http://url");
            var course2 = new OfflineCourse("Math", "Room 101");

            manager.AddTeacher(teacher1);
            manager.AddTeacher(teacher2);
            manager.AddCourse(course1);
            manager.AddCourse(course2);

            manager.AssignTeacherToCourse(0, 0);
            manager.AssignTeacherToCourse(1, 1);

            var coursesJohn = manager.GetCoursesByTeacher(teacher1);
            var coursesMary = manager.GetCoursesByTeacher(teacher2);

            Assert.Single(coursesJohn);
            Assert.Equal(course1, coursesJohn[0]);

            Assert.Single(coursesMary);
            Assert.Equal(course2, coursesMary[0]);
        }

        [Fact]
        public void GetCoursesByTeacher_NoCourses_ShouldReturnEmptyList()
        {
            var manager = new CourseManager();
            var teacher = new Teacher(1, "John");

            manager.AddTeacher(teacher);
            var courses = manager.GetCoursesByTeacher(teacher);

            Assert.Empty(courses);
        }
    }
}

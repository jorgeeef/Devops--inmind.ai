using Microservice_project.Models;

namespace Microservice_project.Services;

public class StudentService
{
    private List<Student> _students;

    public StudentService()
    {
        // Initialize with some sample students
        _students = new List<Student>
        {
            new Student { Id = 1, Name = "Alice", Email = "alice@example.com", Major = "Computer Science" },
            new Student { Id = 2, Name = "Bob", Email = "bob@example.com", Major = "Mathematics" },
            new Student { Id = 3, Name = "Charlie", Email = "charlie@example.com", Major = "Physics" }
        };
    }

    public IEnumerable<Student> GetAllStudents()
    {
        return _students;
    }

    public Student GetStudentById(int id)
    {
        return _students.FirstOrDefault(s => s.Id == id);
    }

    public void AddStudent(Student student)
    {
        _students.Add(student);
    }

    public void UpdateStudent(int id, Student student)
    {
        var existingStudent = _students.FirstOrDefault(s => s.Id == id);
        if (existingStudent != null)
        {
            existingStudent.Name = student.Name;
            existingStudent.Email = student.Email;
            existingStudent.Major = student.Major;
        }
    }

    public void DeleteStudent(int id)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);
        if (student != null)
        {
            _students.Remove(student);
        }
    }
}

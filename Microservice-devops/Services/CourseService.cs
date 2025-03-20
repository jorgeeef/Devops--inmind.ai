using Microservice_project.Models;

namespace Microservice_project.Services;

public class CourseService
{
    private List<Course> _courses;

    public CourseService()
    {
        // Initialize with some sample courses
        _courses = new List<Course>
        {
            new Course { Id = 1, Title = "Introduction to Computer Science", Description = "An introduction to the basics of computer science.", Credits = 3 },
            new Course { Id = 2, Title = "Calculus I", Description = "Basic calculus principles.", Credits = 4 },
            new Course { Id = 3, Title = "Physics I", Description = "Basic principles of physics.", Credits = 4 }
        };
    }

    public IEnumerable<Course> GetAllCourses()
    {
        return _courses;
    }

    public Course GetCourseById(int id)
    {
        return _courses.FirstOrDefault(c => c.Id == id);
    }

    public void AddCourse(Course course)
    {
        _courses.Add(course);
    }

    public void UpdateCourse(int id, Course course)
    {
        var existingCourse = _courses.FirstOrDefault(c => c.Id == id);
        if (existingCourse != null)
        {
            existingCourse.Title = course.Title;
            existingCourse.Description = course.Description;
            existingCourse.Credits = course.Credits;
        }
    }

    public void DeleteCourse(int id)
    {
        var course = _courses.FirstOrDefault(c => c.Id == id);
        if (course != null)
        {
            _courses.Remove(course);
        }
    }
}
using DIWebAPI.Etities;
using DIWebAPI.Services.Interfaces;

namespace DIWebAPI.Services.Implements
{
    public class StudentService : IStudentService
    {
        private readonly List<Student> _students;

        public StudentService()
        {
            _students = new List<Student>();
        }

        public Student AddStudent(Student student)
        {
            student.Id = _students.Count + 1;
            _students.Add(student);
            return student;
        }

        public Student UpdateStudent(int id, Student student)
        {
            var index = _students.FindIndex(s => s.Id == id);
            if (index == -1)
            {
                return null;
            }
            student.Id = id;
            _students[index] = student;
            return student;
        }

        public Student GetStudentById(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }

        public List<Student> GetStudents()
        {
            return _students;
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

}

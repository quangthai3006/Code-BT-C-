using DIWebAPI.Etities;

namespace DIWebAPI.Services.Interfaces
{
    public interface IStudentService
    {
        Student AddStudent(Student student);
        Student UpdateStudent(int id, Student student);
        Student GetStudentById(int id);
        List<Student> GetStudents();
        void DeleteStudent(int id);
    }

}

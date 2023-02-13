using MobileClient.Models;

namespace MobileClient.Services
{
    public interface IStudentService
    {
        List<StudentModel> GetStudentsList();

        int AddStudent(StudentModel student);
        int UpdateStudent(StudentModel student);
        int DeleteStudent(StudentModel student);
    }
}

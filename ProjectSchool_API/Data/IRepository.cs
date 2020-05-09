using System.Threading.Tasks;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data
{
    public interface IRepository
    {
        //General
        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        //Students
        Task<Student[]> GetAllStudentsAsync(bool includeTeacher);

        Task<Student> GetStudentAsyncById(int studentId, bool includeTeacher);

        Task<Student[]> GetStudentAsyncByTeacherId(int teacherId, bool includeTeacher);

        //Teachers
        Task<Teacher[]> GetAllTeachersAsync(bool includeStudent);

        Task<Teacher> GetTeacherAsyncById(int teacherId, bool includeStudent);
    }

}
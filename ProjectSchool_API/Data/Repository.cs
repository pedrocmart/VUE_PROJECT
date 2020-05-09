using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data
{
    public class Repository : IRepository
    {
        public DataContext _context { get; }

        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        //Students

        public async Task<Student[]> GetAllStudentsAsync(bool includeTeacher)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(t => t.Teacher);
            }

            //nolock 
            query = query.AsNoTracking().OrderBy(s => s.ID);

            return await query.ToArrayAsync();
        }

        public async Task<Student> GetStudentAsyncById(int studentId, bool includeTeacher)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(t => t.Teacher);
            }

            //AsNoTracking == nolock 
            query = query.AsNoTracking().Where(s => s.ID == studentId).OrderBy(s => s.ID);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Student[]> GetStudentAsyncByTeacherId(int teacherId, bool includeTeacher)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(t => t.Teacher);
            }

            //nolock 
            query = query.AsNoTracking().Where(t => t.TeacherId == teacherId).OrderBy(s => s.ID);

            return await query.ToArrayAsync();
        }


        //Teachers
        public async Task<Teacher[]> GetAllTeachersAsync(bool includeStudent)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudent)
            {
                query = query.Include(t => t.Students);
            }

            //nolock 
            query = query.AsNoTracking().OrderBy(s => s.ID);

            return await query.ToArrayAsync();
        }

        public async Task<Teacher> GetTeacherAsyncById(int teacherId, bool includeStudent)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudent)
            {
                query = query.Include(s => s.Students);
            }

            //nolock 
            query = query.AsNoTracking().Where(t => t.ID == teacherId).OrderBy(t => t.ID);

            return await query.FirstOrDefaultAsync();
        }
    }
}
using CoreSaveMultiple.Models;
using CoreSaveMultiple.Repo.Contract;

namespace CoreSaveMultiple.Repo.Services
{
    public class StudentService : IStudent
    {
        private readonly StudentOperation _stu;
        public StudentService(StudentOperation stu)
        {
            _stu = stu;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _stu.GetAllStudentsAsync();
        }

        public async Task updateStudentAsync(List<Student> stuList)
        {
            if (stuList != null)
            {
               await _stu.UpdateStudentsAsync(stuList);
            }
        }
    }
}

using CoreSaveMultiple.Models;

namespace CoreSaveMultiple.Repo.Contract
{
    public interface IStudent
    {
        public Task<List<Student>> GetAllStudentsAsync();
        public Task updateStudentAsync(List<Student> stuList);
    }
}


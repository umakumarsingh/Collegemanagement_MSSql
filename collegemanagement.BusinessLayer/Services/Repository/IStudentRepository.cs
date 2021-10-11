using collegemanagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace collegemanagement.BusinessLayer.Services.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudent();
        Task<Student> GetSingleStudentById(int Id);
        Task<Student> AddNewStudent(Student student);
        Task<Student> UpdateStudent(int Id, Student student);
        Task<bool> RemoveStudent(int Id);
    }
}

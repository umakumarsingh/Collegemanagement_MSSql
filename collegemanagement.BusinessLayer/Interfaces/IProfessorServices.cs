using collegemanagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace collegemanagement.BusinessLayer.Services
{
    public interface IProfessorServices
    {
        Task<IEnumerable<Professor>> GetAllProfessor();
        Task<Professor> GetSingleProfessorById(int Id);
        Task<Professor> AddNewProfessor(Professor professor);
        Task<Professor> UpdateProfessor(int Id, Professor professor);
        Task<bool> RemoveProfessor(int Id);
    }
}

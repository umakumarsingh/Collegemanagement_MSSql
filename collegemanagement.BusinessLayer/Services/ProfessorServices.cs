using collegemanagement.BusinessLayer.Services.Repository;
using collegemanagement.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace collegemanagement.BusinessLayer.Services
{
    public class ProfessorServices : IProfessorServices
    {
        /// <summary>
        /// Creating referance variable of IProfessorRepository and injecting in constructor
        /// </summary>
        private readonly IProfessorRepository _professorRepository;
        public ProfessorServices(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }
        /// <summary>
        /// Add new professor in sql database table and throw error if object is null.
        /// </summary>
        /// <param name="professor"></param>
        /// <returns></returns>
        public async Task<Professor> AddNewProfessor(Professor professor)
        {
            return await _professorRepository.AddNewProfessor(professor);
        }
        /// <summary>
        /// Get all professor from sql database table.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Professor>> GetAllProfessor()
        {
            return await _professorRepository.GetAllProfessor();
        }
        /// <summary>
        /// Get Single Professor By Id from sql database table.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Professor> GetSingleProfessorById(int Id)
        {
            return await _professorRepository.GetSingleProfessorById(Id);
        }
        /// <summary>
        /// Remove an existing professor from database.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<bool> RemoveProfessor(int Id)
        {
            return await _professorRepository.RemoveProfessor(Id);
        }
        /// <summary>
        /// Update an existing professor by id and BranchStudy object
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="professor"></param>
        /// <returns></returns>
        public async Task<Professor> UpdateProfessor(int Id, Professor professor)
        {
            return await _professorRepository.UpdateProfessor(Id, professor);
        }
    }
}

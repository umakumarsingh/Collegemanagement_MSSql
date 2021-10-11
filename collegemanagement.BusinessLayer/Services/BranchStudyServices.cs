using collegemanagement.BusinessLayer.Services.Repository;
using collegemanagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace collegemanagement.BusinessLayer.Services
{
    public class BranchStudyServices : IBranchStudyServices
    {
        /// <summary>
        /// Creating referance variable of IBranchStudyRepository and injecting in constructor
        /// </summary>
        private readonly IBranchStudyRepository _bsRepository;
        public BranchStudyServices(IBranchStudyRepository branchStudyRepository)
        {
            _bsRepository = branchStudyRepository;
        }
        /// <summary>
        /// Add new branch study in sql database table and throw error if object is null.
        /// </summary>
        /// <param name="branchStudy"></param>
        /// <returns></returns>
        public async Task<BranchStudy> AddNewBranchStudy(BranchStudy branchStudy)
        {
            return await _bsRepository.AddNewBranchStudy(branchStudy);
        }
        /// <summary>
        /// Get all study of branch from sql database table.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BranchStudy>> GetAllBranchStudy()
        {
            return await _bsRepository.GetAllBranchStudy();
        }
        /// <summary>
        /// Get single branch stsudy from sql database table.
        /// </summary>
        /// <param name="BranchId"></param>
        /// <returns></returns>
        public async Task<BranchStudy> GetSingleBranchById(int BranchId)
        {
            return await _bsRepository.GetSingleBranchById(BranchId);
        }
        /// <summary>
        /// Remove an existing branch of study from database.
        /// </summary>
        /// <param name="BranchId"></param>
        /// <returns></returns>
        public async Task<bool> RemoveBranchStudy(int BranchId)
        {
            return await _bsRepository.RemoveBranchStudy(BranchId);
        }
        /// <summary>
        /// Update an existing branch of study by id and BranchStudy object
        /// </summary>
        /// <param name="BranchId"></param>
        /// <param name="branchStudy"></param>
        /// <returns></returns>
        public async Task<BranchStudy> UpdateBranchStudy(int BranchId, BranchStudy branchStudy)
        {
            return await _bsRepository.UpdateBranchStudy(BranchId, branchStudy);
        }
    }
}

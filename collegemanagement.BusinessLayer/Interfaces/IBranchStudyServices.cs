using collegemanagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace collegemanagement.BusinessLayer.Services
{
    public interface IBranchStudyServices
    {
        Task<IEnumerable<BranchStudy>> GetAllBranchStudy();
        Task<BranchStudy> GetSingleBranchById(int BranchId);
        Task<BranchStudy> AddNewBranchStudy(BranchStudy branchStudy);
        Task<BranchStudy> UpdateBranchStudy(int BranchId, BranchStudy branchStudy);
        Task<bool> RemoveBranchStudy(int BranchId);
    }
}

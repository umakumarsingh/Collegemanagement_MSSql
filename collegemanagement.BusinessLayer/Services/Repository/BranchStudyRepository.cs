using collegemanagement.DataLayer;
using collegemanagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collegemanagement.BusinessLayer.Services.Repository
{
    public class BranchStudyRepository : IBranchStudyRepository
    {
        /// <summary>
        /// Creating referance variable of CollegemanagementDbContext and injecting in constructor
        /// </summary>
        private readonly CollegemanagementDbContext _cmDbContext;
        public BranchStudyRepository(CollegemanagementDbContext collegemanagementDbContext)
        {
            _cmDbContext = collegemanagementDbContext;
        }
        /// <summary>
        /// Add new branch study in sql database table and throw error if object is null.
        /// </summary>
        /// <param name="branchStudy"></param>
        /// <returns></returns>
        public async Task<BranchStudy> AddNewBranchStudy(BranchStudy branchStudy)
        {
            try
            {
                if (branchStudy == null)
                {
                    throw new ArgumentNullException(typeof(BranchStudy).Name + "Object is Null");
                }
                await _cmDbContext.branchStudies.AddAsync(branchStudy);
                await _cmDbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
            return branchStudy;
        }
        /// <summary>
        /// Get all study of branch from sql database table.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BranchStudy>> GetAllBranchStudy()
        {
            try
            {
                return await _cmDbContext.branchStudies.OrderByDescending(x => x.BranchId).ToListAsync();
            }catch(Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get single branch stsudy from sql database table.
        /// </summary>
        /// <param name="BranchId"></param>
        /// <returns></returns>
        public async Task<BranchStudy> GetSingleBranchById(int BranchId)
        {
            try
            {
                return await _cmDbContext.branchStudies
                                 .Where(x => x.BranchId == BranchId)
                                 .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Remove an existing branch of study from database.
        /// </summary>
        /// <param name="BranchId"></param>
        /// <returns></returns>
        public async Task<bool> RemoveBranchStudy(int BranchId)
        {
            try
            {
                bool res = false;
                if (_cmDbContext != null)
                {
                    var study = await _cmDbContext.branchStudies.Where(x => x.BranchId == BranchId)
                    .FirstOrDefaultAsync();
                    if (study != null)
                    {
                        _cmDbContext.branchStudies.Remove(study);
                        await _cmDbContext.SaveChangesAsync();
                    }
                    res = true;
                }
                return res;
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Update an existing branch of study by id and BranchStudy object
        /// </summary>
        /// <param name="BranchId"></param>
        /// <param name="branchStudy"></param>
        /// <returns></returns>
        public async Task<BranchStudy> UpdateBranchStudy(int BranchId, BranchStudy branchStudy)
        {
            if (branchStudy == null && BranchId <= 0)
            {
                throw new ArgumentNullException(typeof(BranchStudy).Name + "Object or may be BranchId is Null");
            }
            var study = await _cmDbContext.branchStudies.Where(x => x.BranchId == BranchId)
                    .FirstOrDefaultAsync();
            try
            {
                if (study != null)
                {
                    study.BranchId = branchStudy.BranchId;
                    study.Branch_Name = branchStudy.Branch_Name;
                    study.Course_Duration = branchStudy.Course_Duration;
                    study.Course_Stream = branchStudy.Course_Stream;
                    study.Basic_Qualification = branchStudy.Basic_Qualification;
                    study.Fees = branchStudy.Fees;

                    await _cmDbContext.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                throw (ex);
            }
            return branchStudy;
        }
    }
}

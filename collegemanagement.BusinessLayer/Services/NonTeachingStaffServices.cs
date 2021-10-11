using collegemanagement.BusinessLayer.Services.Repository;
using collegemanagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace collegemanagement.BusinessLayer.Services
{
    public class NonTeachingStaffServices : INonTeachingStaffServices
    {
        /// <summary>
        /// Creating referance variable of INonTeachingStaffRepository and injecting in constructor
        /// </summary>
        private readonly INonTeachingStaffRepository _ntsRepository;
        public NonTeachingStaffServices(INonTeachingStaffRepository nonTeachingStaffRepository)
        {
            _ntsRepository = nonTeachingStaffRepository;
        }
        /// <summary>
        /// Add New Non Teaching Staff in sql database table and throw error if object is null.
        /// </summary>
        /// <param name="nonTeachingStaff"></param>
        /// <returns></returns>
        public async Task<NonTeachingStaff> AddNewNonTeachingStaff(NonTeachingStaff nonTeachingStaff)
        {
            return await _ntsRepository.AddNewNonTeachingStaff(nonTeachingStaff);
        }
        /// <summary>
        /// Get all Non Teaching Staff from sql database table.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<NonTeachingStaff>> GetAllNonTeachingStaff()
        {
            return await _ntsRepository.GetAllNonTeachingStaff();
        }
        /// <summary>
        /// single Non Teaching Staff details from sql database table.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<NonTeachingStaff> GetSingleNonTeachingStaffById(int Id)
        {
            return await _ntsRepository.GetSingleNonTeachingStaffById(Id);
        }
        /// <summary>
        /// Remove an existing Non Teaching staff from database.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<bool> RemoveNonTeachingStaff(int Id)
        {
            return await _ntsRepository.RemoveNonTeachingStaff(Id);
        }
        /// <summary>
        /// Update an non Teaching Staff by id and NonTeachingStaff object
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="nonTeachingStaff"></param>
        /// <returns></returns>
        public async Task<NonTeachingStaff> UpdateNonTeachingStaff(int Id, NonTeachingStaff nonTeachingStaff)
        {
            return await _ntsRepository.UpdateNonTeachingStaff(Id, nonTeachingStaff);
        }
    }
}

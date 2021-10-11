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
    public class NonTeachingStaffRepository : INonTeachingStaffRepository
    {
        /// <summary>
        /// Creating referance variable of CollegemanagementDbContext and injecting in constructor
        /// </summary>
        private readonly CollegemanagementDbContext _cmDbContext;
        public NonTeachingStaffRepository(CollegemanagementDbContext collegemanagementDbContext)
        {
            _cmDbContext = collegemanagementDbContext;
        }
        /// <summary>
        /// Add New Non Teaching Staff in sql database table and throw error if object is null.
        /// </summary>
        /// <param name="nonTeachingStaff"></param>
        /// <returns></returns>
        public async Task<NonTeachingStaff> AddNewNonTeachingStaff(NonTeachingStaff nonTeachingStaff)
        {
            try
            {
                if (nonTeachingStaff == null)
                {
                    throw new ArgumentNullException(typeof(NonTeachingStaff).Name + "Object is Null");
                }
                await _cmDbContext.nonTeachingStaffs.AddAsync(nonTeachingStaff);
                await _cmDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nonTeachingStaff;
        }
        /// <summary>
        /// Get all Non Teaching Staff from sql database table.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<NonTeachingStaff>> GetAllNonTeachingStaff()
        {
            try
            {
                return await _cmDbContext.nonTeachingStaffs.OrderByDescending(x => x.Id).ToListAsync();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        ///  single Non Teaching Staff details from sql database table.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<NonTeachingStaff> GetSingleNonTeachingStaffById(int Id)
        {
            try
            {
                return await _cmDbContext.nonTeachingStaffs.Where(x => x.Id == Id).FirstOrDefaultAsync();
            }catch(Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Remove an existing Non Teaching staff from database.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<bool> RemoveNonTeachingStaff(int Id)
        {
            try
            {
                bool res = false;
                if (_cmDbContext != null)
                {
                    var staff = await _cmDbContext.nonTeachingStaffs.Where(x => x.Id == Id)
                    .FirstOrDefaultAsync();
                    if (staff != null)
                    {
                        _cmDbContext.nonTeachingStaffs.Remove(staff);
                        await _cmDbContext.SaveChangesAsync();
                    }
                    res = true;
                }
                return res;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Update an non Teaching Staff by id and NonTeachingStaff object
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="nonTeachingStaff"></param>
        /// <returns></returns>
        public async Task<NonTeachingStaff> UpdateNonTeachingStaff(int Id, NonTeachingStaff nonTeachingStaff)
        {
            if (nonTeachingStaff == null && Id <= 0)
            {
                throw new ArgumentNullException(typeof(NonTeachingStaff).Name + "Object or may be Id is Null");
            }
            var staff = await _cmDbContext.nonTeachingStaffs.Where(x => x.Id == Id)
                    .FirstOrDefaultAsync();
            try
            {
                if (staff != null)
                {
                    staff.Id = nonTeachingStaff.Id;
                    staff.Name = nonTeachingStaff.Name;
                    staff.Post = nonTeachingStaff.Post;
                    staff.Contact_Number = nonTeachingStaff.Contact_Number;
                    staff.Email = nonTeachingStaff.Email;
                    staff.Address = nonTeachingStaff.Address;
                    staff.Qualification = nonTeachingStaff.Qualification;

                    await _cmDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nonTeachingStaff;
        }
    }
}

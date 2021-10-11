using collegemanagement.DataLayer;
using collegemanagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collegemanagement.BusinessLayer.Services.Repository
{
    public class CollegeActivityRepository : ICollegeActivityRepository
    {
        /// <summary>
        /// Creating referance variable of CollegemanagementDbContext and injecting in constructor
        /// </summary>
        private readonly CollegemanagementDbContext _cmDbContext;
        public CollegeActivityRepository(CollegemanagementDbContext collegemanagementDbContext)
        {
            _cmDbContext = collegemanagementDbContext;
        }
        /// <summary>
        /// Add new college activity in sql database table and throw erroe if object is null.
        /// </summary>
        /// <param name="collegeActivity"></param>
        /// <returns></returns>
        public async Task<CollegeActivity> AddNewCollegeActivity(CollegeActivity collegeActivity)
        {
            try
            {
                if (collegeActivity == null)
                {
                    throw new ArgumentNullException(typeof(CollegeActivity).Name + "Object is Null");
                }
                await _cmDbContext.activities.AddAsync(collegeActivity);
                await _cmDbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
            return collegeActivity;
        }
        /// <summary>
        /// Get all college activity from sql database table.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CollegeActivity>> GetAllCollegeActivity()
        {
            try
            {
                return await _cmDbContext.activities.OrderByDescending(x => x. Id).ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get single college activity fro sql database table.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<CollegeActivity> GetSingleCollegeActivityById(int Id)
        {
            try
            {
                return await _cmDbContext.activities
                                 .Where(x => x.Id == Id)
                                 .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Remove an existing college activity from database.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<bool> RemoveCollegeActivity(int Id)
        {
            try
            {
                bool res = false;
                if (_cmDbContext != null)
                {
                    var activityRemove = await _cmDbContext.activities.Where(x => x.Id == Id)
                    .FirstOrDefaultAsync();
                    if (activityRemove != null)
                    {
                        _cmDbContext.activities.Remove(activityRemove);
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
        /// Update an existing college activity by id and CollegeActivity object
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="collegeActivity"></param>
        /// <returns></returns>
        public async Task<CollegeActivity> UpdateCollegeActivity(int Id, CollegeActivity collegeActivity)
        {
            if (collegeActivity == null && Id <= 0)
            {
                throw new ArgumentNullException(typeof(CollegeActivity).Name + "Object or may be Activity Id is Null");
            }
            var updateActivity = await _cmDbContext.activities.Where(x => x.Id == Id)
                    .FirstOrDefaultAsync();
            try
            {
                if (updateActivity != null)
                {
                    updateActivity.Id = collegeActivity.Id;
                    updateActivity.Name = collegeActivity.Name;
                    updateActivity.ActivityDate = collegeActivity.ActivityDate;
                    updateActivity.Description = collegeActivity.Description;
                    updateActivity.Venue = collegeActivity.Venue;
                    updateActivity.Type = collegeActivity.Type;

                    await _cmDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return collegeActivity;
        }
    }
}

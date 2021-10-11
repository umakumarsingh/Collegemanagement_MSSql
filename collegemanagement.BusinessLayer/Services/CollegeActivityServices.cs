using collegemanagement.BusinessLayer.Services.Repository;
using collegemanagement.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace collegemanagement.BusinessLayer.Services
{
    public class CollegeActivityServices : ICollegeActivityServices
    {
        /// <summary>
        /// Creating referance variable of ICollegeActivityRepository and injecting in constructor
        /// </summary>
        private readonly ICollegeActivityRepository _caRepository;
        public CollegeActivityServices(ICollegeActivityRepository collegeActivityRepository)
        {
            _caRepository = collegeActivityRepository;
        }
        /// <summary>
        /// Add new college activity in sql database table and throw erroe if object is null.
        /// </summary>
        /// <param name="collegeActivity"></param>
        /// <returns></returns>
        public async Task<CollegeActivity> AddNewCollegeActivity(CollegeActivity collegeActivity)
        {
            return await _caRepository.AddNewCollegeActivity(collegeActivity);
        }
        /// <summary>
        /// Get all college activity from sql database table.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CollegeActivity>> GetAllCollegeActivity()
        {
            return await _caRepository.GetAllCollegeActivity();
        }
        /// <summary>
        /// Get single college activity fro sql database table.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<CollegeActivity> GetSingleCollegeActivityById(int Id)
        {
            return await _caRepository.GetSingleCollegeActivityById(Id);
        }
        /// <summary>
        /// Remove an existing college activity from database.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<bool> RemoveCollegeActivity(int Id)
        {
            return await _caRepository.RemoveCollegeActivity(Id);
        }
        /// <summary>
        /// Update an existing college activity by id and CollegeActivity object
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="collegeActivity"></param>
        /// <returns></returns>
        public async Task<CollegeActivity> UpdateCollegeActivity(int Id, CollegeActivity collegeActivity)
        {
            return await _caRepository.UpdateCollegeActivity(Id, collegeActivity);
        }
    }
}

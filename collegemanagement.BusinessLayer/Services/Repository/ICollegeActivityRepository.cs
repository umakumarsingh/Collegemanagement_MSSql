using collegemanagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace collegemanagement.BusinessLayer.Services.Repository
{
    public interface ICollegeActivityRepository
    {
        Task<IEnumerable<CollegeActivity>> GetAllCollegeActivity();
        Task<CollegeActivity> GetSingleCollegeActivityById(int Id);
        Task<CollegeActivity> AddNewCollegeActivity(CollegeActivity collegeActivity);
        Task<CollegeActivity> UpdateCollegeActivity(int Id, CollegeActivity collegeActivity);
        Task<bool> RemoveCollegeActivity(int Id);
    }
}

using collegemanagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace collegemanagement.BusinessLayer.Services.Repository
{
    public interface INonTeachingStaffRepository
    {
        Task<IEnumerable<NonTeachingStaff>> GetAllNonTeachingStaff();
        Task<NonTeachingStaff> GetSingleNonTeachingStaffById(int Id);
        Task<NonTeachingStaff> AddNewNonTeachingStaff(NonTeachingStaff nonTeachingStaff);
        Task<NonTeachingStaff> UpdateNonTeachingStaff(int Id, NonTeachingStaff nonTeachingStaff);
        Task<bool> RemoveNonTeachingStaff(int Id);
    }
}

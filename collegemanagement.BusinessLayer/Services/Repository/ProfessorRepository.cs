using collegemanagement.DataLayer;
using collegemanagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collegemanagement.BusinessLayer.Services.Repository
{
    public class ProfessorRepository : IProfessorRepository
    {
        /// <summary>
        /// Creating referance variable of CollegemanagementDbContext and injecting in constructor
        /// </summary>
        private readonly CollegemanagementDbContext _cmDbContext;
        public ProfessorRepository(CollegemanagementDbContext collegemanagementDbContext)
        {
            _cmDbContext = collegemanagementDbContext;
        }
        /// <summary>
        /// Add new professor in sql database table and throw error if object is null.
        /// </summary>
        /// <param name="professor"></param>
        /// <returns></returns>
        public async Task<Professor> AddNewProfessor(Professor professor)
        {
            try
            {
                if (professor == null)
                {
                    throw new ArgumentNullException(typeof(Professor).Name + "Object is Null");
                }
                await _cmDbContext.professors.AddAsync(professor);
                await _cmDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return professor;
        }
        /// <summary>
        /// Get all professor from sql database table.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Professor>> GetAllProfessor()
        {
            try
            {
                return await _cmDbContext.professors.OrderByDescending(x => x.Id).ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get Single Professor By Id from sql database table.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Professor> GetSingleProfessorById(int Id)
        {
            try
            {
                return await _cmDbContext.professors
                                 .Where(x => x.Id == Id)
                                 .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Remove an existing professor from database.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<bool> RemoveProfessor(int Id)
        {
            try
            {
                bool res = false;
                if (_cmDbContext != null)
                {
                    var pro = await _cmDbContext.professors.Where(x => x.Id == Id)
                    .FirstOrDefaultAsync();
                    if (pro != null)
                    {
                        _cmDbContext.professors.Remove(pro);
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
        /// Update an existing professor by id and BranchStudy object
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="professor"></param>
        /// <returns></returns>
        public async Task<Professor> UpdateProfessor(int Id, Professor professor)
        {
            if (professor == null && Id <= 0)
            {
                throw new ArgumentNullException(typeof(Professor).Name + "Object or may be Id is Null");
            }
            var pro = await _cmDbContext.professors.Where(x => x.Id == Id)
                    .FirstOrDefaultAsync();
            try
            {
                if (pro != null)
                {
                    pro.Id = professor.Id;
                    pro.Name = professor.Name;
                    pro.Faculty = professor.Faculty;
                    pro.Contact_Number = professor.Contact_Number;
                    pro.Email = professor.Email;
                    pro.Address = professor.Address;
                    pro.Experience = professor.Experience;
                    pro.qualification = professor.qualification;

                    await _cmDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return professor;
        }
    }
}

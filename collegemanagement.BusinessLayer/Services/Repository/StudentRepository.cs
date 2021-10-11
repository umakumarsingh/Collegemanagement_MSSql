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
    public class StudentRepository : IStudentRepository
    {
        /// <summary>
        /// Creating referance variable of CollegemanagementDbContext and injecting in constructor
        /// </summary>
        private readonly CollegemanagementDbContext _cmDbContext;
        public StudentRepository(CollegemanagementDbContext collegemanagementDbContext)
        {
            _cmDbContext = collegemanagementDbContext;
        }
        /// <summary>
        /// Add new student in sql database table and throw error if object is null.
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<Student> AddNewStudent(Student student)
        {
            try
            {
                if (student == null)
                {
                    throw new ArgumentNullException(typeof(Student).Name + "Object is Null");
                }
                await _cmDbContext.students.AddAsync(student);
                await _cmDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return student;
        }
        /// <summary>
        /// Get all student from sql database table.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Student>> GetAllStudent()
        {
            try
            {
                return await _cmDbContext.students.OrderByDescending(x => x.Id).ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get Single student By Id from sql database table.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Student> GetSingleStudentById(int Id)
        {
            try
            {
                return await _cmDbContext.students
                                 .Where(x => x.Id == Id)
                                 .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Remove an existing student from database.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<bool> RemoveStudent(int Id)
        {
            try
            {
                bool res = false;
                if (_cmDbContext != null)
                {
                    var stu = await _cmDbContext.students.Where(x => x.Id == Id)
                    .FirstOrDefaultAsync();
                    if (stu != null)
                    {
                        _cmDbContext.students.Remove(stu);
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
        /// Update an existing student by id and Student object
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<Student> UpdateStudent(int Id, Student student)
        {
            if (student == null && Id <= 0)
            {
                throw new ArgumentNullException(typeof(Student).Name + "Object or may be Id is Null");
            }
            var stu = await _cmDbContext.students.Where(x => x.Id == Id)
                    .FirstOrDefaultAsync();
            try
            {
                if (stu != null)
                {
                    stu.Id = student.Id;
                    stu.Name = student.Name;
                    stu.Contact_Number = student.Contact_Number;
                    stu.Email = student.Email;
                    stu.Course_of_Studiying = student.Course_of_Studiying;
                    stu.Address = student.Address;
                    

                    await _cmDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return student;
        }
    }
}

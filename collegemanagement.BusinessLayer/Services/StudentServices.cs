using collegemanagement.BusinessLayer.Services.Repository;
using collegemanagement.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace collegemanagement.BusinessLayer.Services
{
    public class StudentServices : IStudentServices
    {
        /// <summary>
        /// Creating referance variable of IStudentRepository and injecting in constructor
        /// </summary>
        private readonly IStudentRepository _studentRepository;
        public StudentServices(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        /// <summary>
        /// Add new student in sql database table and throw error if object is null.
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<Student> AddNewStudent(Student student)
        {
            return await _studentRepository.AddNewStudent(student);
        }
        /// <summary>
        /// Get all student from sql database table.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Student>> GetAllStudent()
        {
            return await _studentRepository.GetAllStudent();
        }
        /// <summary>
        /// Get Single student By Id from sql database table.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Student> GetSingleStudentById(int Id)
        {
            return await _studentRepository.GetSingleStudentById(Id);
        }
        /// <summary>
        /// Remove an existing student from database.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<bool> RemoveStudent(int Id)
        {
            return await _studentRepository.RemoveStudent(Id);
        }
        /// <summary>
        /// Update an existing student by id and Student object
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<Student> UpdateStudent(int Id, Student student)
        {
            return await _studentRepository.UpdateStudent(Id, student);
        }
    }
}

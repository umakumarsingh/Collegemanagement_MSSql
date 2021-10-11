using collegemanagement.BusinessLayer.Services;
using collegemanagement.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collegemanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        /// <summary>
        /// Creating the field of IStudentServices and injecting in StudentController constructor
        /// </summary>
        private readonly IStudentServices _studentServices;
        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }
        /// <summary>
        /// call the default get method to get all student information
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Student>> GetAllStudent()
        {
            return await _studentServices.GetAllStudent();
        }
        /// <summary>
        /// call the default get method with Id to get student information
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async Task<ActionResult<Student>> GetSingleStudent(int Id)
        {
            if (Id <= 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Id not Correct!" });
            }
            var result = await _studentServices.GetSingleStudentById(Id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        /// <summary>
        /// Add new student in database and show the status is added
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddNewStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _studentServices.AddNewStudent(student);
            return CreatedAtAction("GetAllStudent", student);
        }
        /// <summary>
        /// Update an existing student by Id and Student Model, All method must call await
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateStudent(int Id, [FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getStudent = await _studentServices.GetSingleStudentById(Id);
            if (getStudent == null)
            {
                return NotFound();
            }
            //Call await UpdateStudent method to change an existing data with supplied data
            await _studentServices.UpdateStudent(Id, student);
            return CreatedAtAction("GetAllStudent", student);
        }
        /// <summary>
        /// Delete an existing student by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveStudent(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest();
            }
            try
            {
                var result = await _studentServices.RemoveStudent(Id);
                if (result == false)
                {
                    return NotFound();
                }
                return Ok("A student Deleted...");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}

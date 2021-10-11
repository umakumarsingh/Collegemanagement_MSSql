using collegemanagement.BusinessLayer.Services;
using collegemanagement.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace collegemanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        /// <summary>
        /// Creating the field of IProfessorServices and injecting in ProfessorController constructor
        /// </summary>
        private readonly IProfessorServices _professorServices;
        public ProfessorController(IProfessorServices professorServices)
        {
            _professorServices = professorServices;
        }
        /// <summary>
        /// call the default get method to get all professor information
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Professor>> GetAllProfessor()
        {
            return await _professorServices.GetAllProfessor();
        }
        /// <summary>
        /// call the default get method with Id to get professor Staff information
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async Task<ActionResult<Professor>> GetSingleProfessor(int Id)
        {
            if (Id <= 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Id not Correct!" });
            }
            var result = await _professorServices.GetSingleProfessorById(Id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        /// <summary>
        /// Add new professor in database and show the status is added
        /// </summary>
        /// <param name="professor"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddNewProfessor([FromBody] Professor professor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _professorServices.AddNewProfessor(professor);
            return CreatedAtAction("GetAllProfessor", professor);
        }
        /// <summary>
        /// Update an existing professor by Id and Professor Model, All method must call await
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="professor"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateProfessor(int Id, [FromBody] Professor professor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getprofessor = await _professorServices.GetSingleProfessorById(Id);
            if (getprofessor == null)
            {
                return NotFound();
            }
            //Call await UpdateProfessor method to change an existing data with supplied data
            await _professorServices.UpdateProfessor(Id, professor);
            return CreatedAtAction("GetAllProfessor", professor);
        }
        /// <summary>
        /// Delete an existing professor by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveProfessor(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest();
            }
            try
            {
                var result = await _professorServices.RemoveProfessor(Id);
                if (result == false)
                {
                    return NotFound();
                }
                return Ok("Professor Deleted...");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}

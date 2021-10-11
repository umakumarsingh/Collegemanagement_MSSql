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
    public class NonTeachingStaffController : ControllerBase
    {
        /// <summary>
        /// Creating the field of ICollegeActivityServices and injecting in NonTeachingStaffController constructor
        /// </summary>
        private readonly INonTeachingStaffServices _ntServices;
        public NonTeachingStaffController(INonTeachingStaffServices nonTeachingStaff)
        {
            _ntServices = nonTeachingStaff;
        }
        /// <summary>
        /// call the default get method to get all Non-Teaching Staff information
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<NonTeachingStaff>> GetAllNonTeachingStaff()
        {
            return await _ntServices.GetAllNonTeachingStaff();
        }
        /// <summary>
        /// call the default get method with Id to get Non-Teaching Staff information
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async Task<ActionResult<NonTeachingStaff>> GetSingleNonTeachingStaff(int Id)
        {
            if (Id <= 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Id not Correct!" });
            }
            var result = await _ntServices.GetSingleNonTeachingStaffById(Id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        /// <summary>
        /// Add new Non-Teaching Staff in database and show the status is added
        /// </summary>
        /// <param name="nonTeachingStaff"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddNewNonTeachingStaff([FromBody] NonTeachingStaff nonTeachingStaff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _ntServices.AddNewNonTeachingStaff(nonTeachingStaff);
            return CreatedAtAction("GetAllNonTeachingStaff", nonTeachingStaff);
        }
        /// <summary>
        /// Update an existing non-teaching staff by Id and NonTeachingStaff Model, All method must call await
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="nonTeachingStaff"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateNonTeachingStaff(int Id, [FromBody] NonTeachingStaff nonTeachingStaff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getStaff = await _ntServices.GetSingleNonTeachingStaffById(Id);
            if (getStaff == null)
            {
                return NotFound();
            }
            //Call await UpdateNonTeachingStaff method to change an existing data with supplied data
            await _ntServices.UpdateNonTeachingStaff(Id, nonTeachingStaff);
            return CreatedAtAction("GetAllNonTeachingStaff", nonTeachingStaff);
        }
        /// <summary>
        /// Delete an existing Non-Teaching staff by staff Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveNonTeachingStaff(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest();
            }
            try
            {
                var result = await _ntServices.RemoveNonTeachingStaff(Id);
                if (result == false)
                {
                    return NotFound();
                }
                return Ok("Non-Teaching staff Deleted...");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}

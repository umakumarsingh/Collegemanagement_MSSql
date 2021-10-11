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
    public class CollegeActivityController : ControllerBase
    {
        /// <summary>
        /// Creating the field of ICollegeActivityServices and injecting in CollegeActivityController constructor
        /// </summary>
        private readonly ICollegeActivityServices _caServices;
        public CollegeActivityController(ICollegeActivityServices collegeActivity)
        {
            _caServices = collegeActivity;
        }
        /// <summary>
        /// call the default get method to get all college activity information
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<CollegeActivity>> GetAllCollegeActivity()
        {
            return await _caServices.GetAllCollegeActivity();
        }
        /// <summary>
        /// call the default get method with Id to get college activity information
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async Task<ActionResult<CollegeActivity>> GetSingleCollegeActivity(int Id)
        {
            if (Id <= 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Id not Correct!" });
            }
            var result = await _caServices.GetSingleCollegeActivityById(Id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        /// <summary>
        /// Add new College activity in database and show the status is added
        /// </summary>
        /// <param name="collegeActivity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddNewCollegeActivity([FromBody] CollegeActivity collegeActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _caServices.AddNewCollegeActivity(collegeActivity);
            return CreatedAtAction("GetAllCollegeActivity", collegeActivity);
        }
        /// <summary>
        /// Update an existing activity by Id and CollegeActivity Model, All method must call await
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="collegeActivity"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateCollegeActivity(int Id, [FromBody] CollegeActivity collegeActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getActivity = await _caServices.GetSingleCollegeActivityById(Id);
            if (getActivity == null)
            {
                return NotFound();
            }
            //Call await UpdateBranchStudy method to change an existing data with supplied data
            await _caServices.UpdateCollegeActivity(Id, collegeActivity);
            return CreatedAtAction("GetAllCollegeActivity", collegeActivity);
        }
        /// <summary>
        /// Delete an existing Activity by Activity Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveCollegeActivity(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest();
            }
            try
            {
                var result = await _caServices.RemoveCollegeActivity(Id);
                if (result == false)
                {
                    return NotFound();
                }
                return Ok("College Activity Deleted...");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}

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
    public class BranchStudyController : ControllerBase
    {
        /// <summary>
        /// Creating the field of IBranchStudyServices and injecting in ClerkController constructor
        /// </summary>
        private readonly IBranchStudyServices _bsServices;
        public BranchStudyController(IBranchStudyServices branchStudy)
        {
            _bsServices = branchStudy;
        }
        /// <summary>
        /// call the default get method to get all branch study information
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<BranchStudy>> GetAllBranchStudy()
        {
            return await _bsServices.GetAllBranchStudy();
        }
        /// <summary>
        /// call the default get method with branch Id to get branch study information
        /// </summary>
        /// <param name="BranchId"></param>
        /// <returns></returns>
        [HttpGet("{BranchId}")]
        public async Task<ActionResult<BranchStudy>> GetSingleBranch(int BranchId)
        {
            if(BranchId <= 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Id not correct!" });
            }
            var result = await _bsServices.GetSingleBranchById(BranchId);
            if(result == null)
            {
                return NotFound();
            }
            return result;
        }
        /// <summary>
        /// Add new branch study in database and show the status is added
        /// </summary>
        /// <param name="branchStudy"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddNewBranchStudy([FromBody] BranchStudy branchStudy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _bsServices.AddNewBranchStudy(branchStudy);
            return CreatedAtAction("GetAllBranchStudy", branchStudy);
        }
        /// <summary>
        /// Update an existing Branch by Id and Branch Model, All method must call await
        /// </summary>
        /// <param name="BranchId"></param>
        /// <param name="branchStudy"></param>
        /// <returns></returns>
        [HttpPut("{BranchId}")]
        public async Task<IActionResult> UpdateBranchStudy(int BranchId, [FromBody] BranchStudy branchStudy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getBranch = await _bsServices.GetSingleBranchById(BranchId);
            if (getBranch == null)
            {
                return NotFound();
            }
            //Call await UpdateBranchStudy method to change an existing data with supplied data
            await _bsServices.UpdateBranchStudy(BranchId, branchStudy);
            return CreatedAtAction("GetAllBranchStudy", branchStudy);
        }
        /// <summary>
        /// Delete an existing branch by Branch Id
        /// </summary>
        /// <param name="BranchId"></param>
        /// <returns></returns>
        [HttpDelete("{BranchId}")]
        public async Task<IActionResult> RemoveBranchStudy(int BranchId)
        {
            if (BranchId <= 0)
            {
                return BadRequest();
            }
            try
            {
                var result = await _bsServices.RemoveBranchStudy(BranchId);
                if (result == false)
                {
                    return NotFound();
                }
                return Ok("Branch Study Deleted...");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}

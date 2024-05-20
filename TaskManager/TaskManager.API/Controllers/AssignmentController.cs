using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.InputModels;
using TaskManager.Application.Services.Interfaces;
using TaskManager.Core.Enums;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;
        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            try
            {
                var assignment = await _assignmentService.GetByIdAsync(id);

                return Ok(assignment);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("post")]
        public async Task<IActionResult> Post([FromBody] CreateAssignmentInputModel inputModel)
        {
            try
            {
                var id = await _assignmentService.CreateAsync(inputModel);

                return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getall")]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var assignments = await _assignmentService.GetAllAsync();

                return Ok(assignments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }       
        }

        [HttpGet("getbystatus/{status}")]
        public async Task<IActionResult> GetByStatus(EnumAssignmentStatus status)
        {
            try
            {
                var assignments = await _assignmentService.GetByStatusAsync(status);

                return Ok(assignments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }     
        }

        [HttpGet("getbydate/{date}")]
        public async Task<IActionResult> GetByDate(DateTime date)
        {
            try
            {
                var assignments = await _assignmentService.GetByDateAsync(date);

                return Ok(assignments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("getbytitle/{title}")]
        public async Task<IActionResult> GetByTitle(string title)
        {
            try
            {
                var assignments = await _assignmentService.GetByTitleAsync(title);

                return Ok(assignments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] UpdateAssignmentInputModel inputModel)
        {
            try
            {
                await _assignmentService.UpdateAsync(id, inputModel);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }  
        }

        [HttpPut("finish/{id}")]
        public async Task<IActionResult> Finish(int id)
        {
            try
            {
                await _assignmentService.FinishAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _assignmentService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}

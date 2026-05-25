using Microsoft.AspNetCore.Mvc;
using Practical_18.Models;
using Practical_18.Services.Interfaces;

namespace Practical_18.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentApiController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            await _service.CreateAsync(student);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Student student)
        {
            await _service.UpdateAsync(student);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
    }
}

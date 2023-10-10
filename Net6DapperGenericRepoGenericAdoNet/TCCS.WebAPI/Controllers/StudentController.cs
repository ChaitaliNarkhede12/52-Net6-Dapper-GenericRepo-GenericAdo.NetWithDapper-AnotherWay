using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCCS.DataAccess.Interfaces;
using TCCS.DataAccess.Models;

namespace TCCS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _studentRepository.GetList();
            return Ok(res);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _studentRepository.GetById(id);
            return Ok(res);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(Student entity)
        {
            var res = await _studentRepository.AddAsync(entity);
            return Ok(res);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(Student entity)
        {
            var res = await _studentRepository.UpdateAsync(entity);
            return Ok(res);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _studentRepository.RemoveAsync(id);
            return Ok(res);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proApi1.DTO;
using proApi1.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace proApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly MMContext _context;
        public DepartmentController(MMContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetDepartment()
        {
  
            List<Department>dept=_context.Departments.Include(e=>e.Employee).ToList();
            List<DepartmentWithEmolyeeNameDTO> deptDto=new List<DepartmentWithEmolyeeNameDTO>();
            foreach(var item in dept)
            {
                DepartmentWithEmolyeeNameDTO deptDate = new DepartmentWithEmolyeeNameDTO();
                deptDate.Name=item.Name;
                foreach(var emp in item.Employee)
                {
                    deptDate.EmployeeName.Add(emp.Name);
                }
                deptDto.Add(deptDate);
            }
            return Ok(deptDto);
        }
        [HttpGet("{Id:int}")]
        public IActionResult GetDepartmentDetails(int Id)
        {
            var dept=_context.Departments.Include(e=>e.Employee).FirstOrDefault(d=>d.Id==Id);
            DepartmentWithEmolyeeNameDTO deptDto = new DepartmentWithEmolyeeNameDTO();
            deptDto.Name = dept.Name; 
            foreach(var item in dept.Employee)
            {
                deptDto.EmployeeName.Add(item.Name);
            }
            return Ok(deptDto);
        }
        [HttpPost]
        public IActionResult Create(DepartmentDTO deptDTO)
        {
            if (ModelState.IsValid)
            {
                var dept = new Department
                {
                    Name = deptDTO.Name
                };
                _context.Departments.Add(dept);
                _context.SaveChanges();
                string url = Url.Link("GetEmployeeCreated", new { Id = dept.Id });
                return Created(url, dept);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{Id:int}")]
        public IActionResult Edit([FromRoute] int Id, [FromBody] DepartmentDTO deptDTO)
        {
            var olddept = _context.Departments.FirstOrDefault(d => d.Id == Id);
            olddept.Name = deptDTO.Name;
            _context.SaveChanges();
            return StatusCode(204, "date is update");
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proApi1.Models;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using proApi1.DTO;

namespace proApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly MMContext _context;
        public EmployeeController(MMContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetEmployee()
        {
            var emp = _context.Employees.Include(d=>d.Department).ToList();
           List<EmployeeDataWithDepartmenNameDTO> empDto=new List<EmployeeDataWithDepartmenNameDTO>();
            foreach(var item in emp)
            {
                EmployeeDataWithDepartmenNameDTO empData = new EmployeeDataWithDepartmenNameDTO();
                empData.Id = item.Id;
                empData.EmployeeName = item.Name;
                empData.EmployeePhone = item.Phone;
                empData.EmployeeAdress = item.Address;
                empData.DepartmentName = item.Department.Name;
                empDto.Add(empData);
            }

            if (emp!=null)
            {
                return Ok(empDto);
            }
            return BadRequest("Not Employee");
        }
        [HttpGet("{Id:int}",Name = "GetEmployeeCreated")]
        public IActionResult Details(int Id)
        {
            var emp = _context.Employees.Include(d=>d.Department).FirstOrDefault(x => x.Id == Id);
            EmployeeDataWithDepartmenNameDTO empDto=new EmployeeDataWithDepartmenNameDTO();
            empDto.Id = emp.Id;
            empDto.EmployeeName = emp.Name;
            empDto.EmployeePhone= emp.Phone;
            empDto.EmployeeAdress = emp.Address;
            empDto.DepartmentName = emp.Department.Name;
            if (emp != null) 
            {
                return Ok(empDto);
            }
            return BadRequest("ID Not Valid");
        }
        //Create with Model
        //[HttpPost]
        //public IActionResult CreataEmployee(Employee employee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Employees.Add(employee);
        //        _context.SaveChanges();
        //        string url=Url.Link("GetEmployeeCreated", new { Id = employee.Id });
        //        return Created(url, employee);
        //    }
        //    return BadRequest(ModelState);
        //}
        [HttpPost]
        public IActionResult CreataEmployee(EmployeeDTO employeeDTO)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Name = employeeDTO.Name,
                    Address = employeeDTO.Address,
                    Phone = employeeDTO.Phone,
                    Salary = employeeDTO.Salary,
                    DeptID = employeeDTO.DeptID
                };
                _context.Employees.Add(employee);
                _context.SaveChanges();
                string url = Url.Link("GetEmployeeCreated", new { Id = employee.Id });
                return Created(url, employee);
            }
            return BadRequest(ModelState);
        }
        //[HttpPut("{Id:int}")]
        //public IActionResult update([FromRoute] int Id, [FromBody]Employee employee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var oldemployee=_context.Employees.FirstOrDefault(x => x.Id == Id);
        //        oldemployee.Name = employee.Name;
        //        oldemployee.Address=employee.Address;
        //        oldemployee.Phone=employee.Phone;
        //        oldemployee.Salary = employee.Salary;
        //        _context.SaveChanges();
        //        return StatusCode(204, employee); ;
        //    }
        //    return BadRequest(ModelState);
        //}
        [HttpPut("{Id:int}")]
        public IActionResult update([FromRoute] int Id, [FromBody] EmployeeDTO employee)
        {
            if (ModelState.IsValid)
            {
                var oldemployee = _context.Employees.FirstOrDefault(x => x.Id == Id);
                oldemployee.Name = employee.Name;
                oldemployee.Address = employee.Address;
                oldemployee.Phone = employee.Phone;
                oldemployee.Salary = employee.Salary;
                oldemployee.DeptID=employee.DeptID;
                _context.SaveChanges();
                return StatusCode(204, employee); ;
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{Id:int}")]
        public IActionResult Remove(int Id)
        {
            var emp=_context.Employees.FirstOrDefault(x=>x.Id==Id);
            _context.Employees.Remove(emp);
            _context.SaveChanges();
            return StatusCode(204, "Record is Delete");
        }
    }
}

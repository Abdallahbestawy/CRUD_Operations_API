using proApi1.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace proApi1.DTO
{
    public class EmployeeDTO
    {


        public int Id { get; set; }
        [Required, StringLength(500)]
        public string Name { get; set; }
        public string? Address { get; set; }
        public double Salary { get; set; }
        [Required, StringLength(11)]
        public string Phone { get; set; }
        public int? DeptID { get; set; }
    }
}

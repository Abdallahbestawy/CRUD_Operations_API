using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proApi1.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Required,MaxLength(500)]
        public string Name { get; set; }
        public string? Address { get; set; }
        public double Salary { get; set; }
        [Required,MaxLength(11)]
        public string Phone { get; set; }
        [ForeignKey("Department")]
        public int? DeptID { get; set; }
        public virtual Department Department { get; set; }
    }
}

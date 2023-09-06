using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace proApi1.DTO
{
    public class DepartmentDTO
    {
      
        public int Id { get; set; }
        [Required, StringLength(250)]
        public string Name { get; set; }
    }
}

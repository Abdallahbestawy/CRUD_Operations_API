using proApi1.Models;

namespace proApi1.DTO
{
    public class DepartmentWithEmolyeeNameDTO
    {
        public string Name { get; set; }
        public List<String> EmployeeName { get; set; } = new List<string>();
    }
}

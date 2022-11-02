using SamplePRojectOverleap.DatabaseConnection;
using System.ComponentModel.DataAnnotations;

namespace SamplePRojectOverleap.Models
{
    public class EmployeeViewModel
    {
        [Required(ErrorMessage = "Requird filed")]
        public string Name { get; set; }

        [Required]
        public string Workingdays { get; set; }
    }

    public class EmployeeListViewModel
    {
        public List<TblEmployee> TblEmployees { get; set; }
    }

    public class EditEmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Workingdays { get; set; }
    }
}

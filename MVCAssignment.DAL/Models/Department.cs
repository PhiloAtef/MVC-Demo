using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCAssignment.DAL.Models
{
    public class Department : ModelBase
    {
        
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage ="code is required")]
        public string Code { get; set; }
        [Display(Name="Date Of Creation")]
        public DateTime DateOfCreation { get; set; }
        //Navigation property
        [InverseProperty(nameof(Models.Employee.Department))]
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}

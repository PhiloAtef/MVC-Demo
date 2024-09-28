using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MVCAssignment.DAL.Models
{
    public enum Gender
    {
        [EnumMember(Value ="Male")]
        Male = 1,
        [EnumMember(Value = "Female")]
        Female = 2
    }

    enum EmployeeType
    {
        [EnumMember(Value = "FullTime")]
        FullTime = 1,
        [EnumMember(Value = "PartTime")]
        PartTime = 2
    }
    public class Employee : ModelBase
    {
        

        [Required(ErrorMessage ="Name is required")]
        [MaxLength(50,ErrorMessage ="Max length is 50")]
        [MinLength(4,ErrorMessage ="Min Length is 4")]
        public string Name { get; set; }
        [Range(21,60)]
        public int? Age { get; set; }
        [RegularExpression(@"[0-9]{1,3}-[a-zA-Z]{5,10}=[a-zA-Z]{4,10}=[a-zA-Z]{5,10}$"
                           , ErrorMessage ="Address Must be like 123-street-city-country")]
        public string Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public bool IsActive {  get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name ="Hire Date")]
        public DateTime HireDate { get; set; }

        public bool IsDeleted { get; set; }

        public Gender Gender { get; set; }

        public Department Department { get; set; }

        //Fk column
        [InverseProperty(nameof(Models.Department.Employees))]
        public int? DepartmentId { get; set; }
    }
}

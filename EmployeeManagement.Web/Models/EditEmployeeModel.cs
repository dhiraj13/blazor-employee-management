using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Models;
using EmployeeManagement.Models.CustomValidators;

namespace EmployeeManagement.Web.Models
{
  public class EditEmployeeModel
  {
    public int EmployeeId { get; set; }
    [Required(ErrorMessage = "First Name must be provided")]
    [MinLength(2)]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last Name must be provided")]
    public string LastName { get; set; }
    [EmailAddress]
    [EmailDomainValidator(AllowedDomain = "msrd.com", ErrorMessage = "Only msrd.com is allowed")]
    public string Email { get; set; }
    [CompareProperty("Email", ErrorMessage = "Email and Confirm Email must match")]
    public string ConfirmEmail { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    public string PhotoPath { get; set; }
  }
}
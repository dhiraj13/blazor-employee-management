using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
  public class Employee
  {
    public int EmployeeId { get; set; }
    [MinLength(2)]
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public int DepartmentId { get; set; }
    public string PhotoPath { get; set; }
  }
}
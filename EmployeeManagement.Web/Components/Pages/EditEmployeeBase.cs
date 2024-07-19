using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Components.Pages
{
  public class EditEmployeeBase : ComponentBase
  {
    [Inject]
    public IEmployeeService EmployeeService { get; set; }

    private Employee Employee { get; set; } = new Employee();

    public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();

    [Inject]
    public IDepartmentService DepartmentService { get; set; }

    public List<Department> Departments { get; set; } = new List<Department>();

    [Parameter]
    public string Id { get; set; }

    [Inject]
    public IMapper Mapper { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
      int.TryParse(Id, out int employeeId);

      if (employeeId != 0)
      {
        Employee = await EmployeeService.GetEmployee(int.Parse(Id));
      }
      else
      {
        Employee = new Employee
        {
          DepartmentId = 1,
          Department = new Department { DepartmentId = 1, DepartmentName = "IT" },
          DateOfBirth = DateTime.Now,
          PhotoPath = "images/nophoto.jpg"
        };
      }

      Departments = (await DepartmentService.GetDepartments()).ToList();
      Mapper.Map(Employee, EditEmployeeModel);
    }

    protected async void HandleValidSumbit()
    {
      Mapper.Map(EditEmployeeModel, Employee);
      try
      {
        Employee result = null;
        if (Employee.EmployeeId != 0)
        {
          result = await EmployeeService.UpdateEmployee(Employee);
        }
        else
        {
          result = await EmployeeService.CreateEmployee(Employee);
        }
        if (result != null)
        {
          NavigationManager.NavigateTo("/");
        }
      }
      catch (HttpRequestException ex)
      {
        Console.WriteLine($"Error updating employee: {ex.Message}");
      }
    }
  }
}
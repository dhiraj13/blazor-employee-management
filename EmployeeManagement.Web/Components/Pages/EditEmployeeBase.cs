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

    protected override async Task OnInitializedAsync()
    {
      Employee = await EmployeeService.GetEmployee(int.Parse(Id));
      Departments = (await DepartmentService.GetDepartments()).ToList();

      Mapper.Map(Employee, EditEmployeeModel);
    }

    protected void HandleValidSumbit()
    {

    }
  }
}
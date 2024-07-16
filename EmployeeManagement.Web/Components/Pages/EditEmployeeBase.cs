using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Components.Pages
{
  public class EditEmployeeBase : ComponentBase
  {
    [Inject]
    public IEmployeeService EmployeeService { get; set; }

    public Employee Employee { get; set; } = new Employee();

    [Parameter]
    public string Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
      Employee = await EmployeeService.GetEmployee(int.Parse(Id));
    }
  }
}
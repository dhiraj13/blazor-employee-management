using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Components.Pages
{
  public class EmployeeListBase : ComponentBase
  {
    [Inject]
    public IEmployeeService EmployeeService { get; set; }

    public bool ShowFooter { get; set; } = true;

    public IEnumerable<Employee> Employees { get; set; }

    protected override async Task OnInitializedAsync()
    {
      Employees = (await EmployeeService.GetEmployees()).ToList();
    }

    protected int SelectedEmployeeCount { get; set; } = 0;

    protected void EmployeeSelectionChanged(bool isSelected)
    {
      if (isSelected)
      {
        SelectedEmployeeCount++;
      }
      else
      {
        SelectedEmployeeCount--;
      }
    }
  }
}
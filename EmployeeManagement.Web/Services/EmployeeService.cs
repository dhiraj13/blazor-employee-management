using EmployeeManagement.Models;

namespace EmployeeManagement.Web.Services
{
  public class EmployeeService : IEmployeeService
  {
    private readonly HttpClient _httpClient;

    public EmployeeService(HttpClient httpClient)
    {
      this._httpClient = httpClient;
    }
    public async Task<IEnumerable<Employee>> GetEmployees()
    {
      return await _httpClient.GetFromJsonAsync<Employee[]>("api/employees");
    }
  }
}
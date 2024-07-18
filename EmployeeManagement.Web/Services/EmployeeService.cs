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

    public async Task<Employee> GetEmployee(int id)
    {
      return await _httpClient.GetFromJsonAsync<Employee>($"api/employees/{id}");
    }

    public async Task<Employee> UpdateEmployee(Employee updatedEmployee)
    {
      HttpResponseMessage response = await _httpClient.PutAsJsonAsync("api/employees", updatedEmployee);

      if (response.IsSuccessStatusCode)
      {
        Employee updatedEmployeeResult = await response.Content.ReadFromJsonAsync<Employee>();
        return updatedEmployeeResult;
      }
      else
      {
        throw new HttpRequestException($"Error updating employee: {response.ReasonPhrase}");
      }
    }
  }
}
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

    public async Task<Employee> CreateEmployee(Employee newEmployee)
    {
      HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/employees", newEmployee);

      if (response.IsSuccessStatusCode)
      {
        Employee createdEmployee = await response.Content.ReadFromJsonAsync<Employee>();
        return createdEmployee;
      }
      else
      {
        string errorResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Error creating employee: {errorResponse}");
        // Handle the error as needed, for example, logging it or throwing an exception
        throw new HttpRequestException($"Error creating employee: {response.ReasonPhrase}");
      }
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
using EmployeeManagement.Web.Components;
using EmployeeManagement.Web.Models;
using EmployeeManagement.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddAutoMapper(typeof(EmployeeProfile));
builder.Services.AddHttpClient<IEmployeeService, EmployeeService>(client =>
{
  client.BaseAddress = new Uri("http://localhost:5292/");
});
builder.Services.AddHttpClient<IDepartmentService, DepartmentService>(client =>
{
  client.BaseAddress = new Uri("http://localhost:5292/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error", createScopeForErrors: true);
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

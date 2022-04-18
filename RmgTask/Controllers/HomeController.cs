using Microsoft.AspNetCore.Mvc;
using RmgTask.Models;
using RmgTask.Repository;
using System.Diagnostics;

namespace RmgTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(ILogger<HomeController> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository=employeeRepository;
        }

        public async Task<IActionResult> IndexAsync()
        {
            await _employeeRepository.CreateAsync(new Employee
            {
                Id = Guid.NewGuid(),
                Name = "a",
                Address = "cscdcc",
                Phone = "0536813995",
                Salary = 150000
            });
            var emp = await _employeeRepository.GetEmployeesAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
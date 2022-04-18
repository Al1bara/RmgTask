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
            var emp = await _employeeRepository.GetEmployeesAsync();
            return View(emp);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> CreateUserAsync(Employee? employee)
        {
            if (employee.Name == null)
            {
                return View();
            }
            else
            {
                await _employeeRepository.CreateAsync(employee);
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _employeeRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid Id)
        {
            var employee = await _employeeRepository.GetEmployeeAsync(Id);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            await _employeeRepository.UpdateAsync(employee);
            return RedirectToAction("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
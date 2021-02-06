using HandsOnTest.Employees.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HandsOnTest.Employees.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET api/employee
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _employeeService.GetEmployees());
        }

        // GET api/employee/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);

            if (employee!=null)
                return Ok(employee);

            return NotFound("Employee Not Found");
        }
    }
}

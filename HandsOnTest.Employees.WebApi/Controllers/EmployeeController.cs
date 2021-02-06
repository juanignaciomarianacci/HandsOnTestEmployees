using HandsOnTest.Employees.Service;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Get()
        {
            return Ok(_employeeService.GetEmployees());
        }

        // GET api/employee/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);

            if (employee!=null)
                return Ok(employee);

            return NotFound("Employee Not Found");
        }
    }
}

using HandsOnTest.Employees.Business.Contract;
using HandsOnTest.Employees.Business.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandsOnTest.Employees.Service
{
    public class EmployeeService
    {
        private readonly IEmployeeProvider _employeeProvider;

        public EmployeeService(IEmployeeProvider employeeProvider)
        {
            _employeeProvider = employeeProvider;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployees()
        {
            return await _employeeProvider.GetEmployees();
        }

        public async Task<EmployeeDto> GetEmployeeById(int employeeId)
        {
            return await _employeeProvider.GetEmployeeById(employeeId);
        }
    }
}

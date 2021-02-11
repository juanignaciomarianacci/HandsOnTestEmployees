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

        public Task<IEnumerable<EmployeeDto>> GetEmployees()
        {
            return _employeeProvider.GetEmployees();
        }

        public Task<EmployeeDto> GetEmployeeById(int employeeId)
        {
            return _employeeProvider.GetEmployeeById(employeeId);
        }
    }
}

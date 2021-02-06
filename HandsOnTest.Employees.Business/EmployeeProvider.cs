using HandsOnTest.Employees.Business.Contract;
using HandsOnTest.Employees.Business.Dto;
using HandsOnTest.Employees.DataAccess.Repository.Contract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandsOnTest.Employees.Business
{
    public class EmployeeProvider : IEmployeeProvider
    {
        private IEmployeeFactory _employeeFactory;
        private IEmployeeRepository _employeeRepository;

        public EmployeeProvider(IEmployeeRepository employeeRepository, IEmployeeFactory employeeFactory)
        {
            _employeeRepository = employeeRepository;
            _employeeFactory = employeeFactory;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployees()
        {
            var employees = await _employeeRepository.GetEmployees();
            
            return employees.Select(e => _employeeFactory.Create(e));
        }

        public async Task<EmployeeDto> GetEmployeeById(int employeeId)
        {
            var employee = await _employeeRepository.GetEmployeeById(employeeId);
            
            return _employeeFactory.Create(employee);
        }
    }
}

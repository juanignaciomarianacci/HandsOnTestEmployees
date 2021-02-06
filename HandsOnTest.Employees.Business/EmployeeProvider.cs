using HandsOnTest.Employees.Business.Contract;
using HandsOnTest.Employees.Business.Dto;
using HandsOnTest.Employees.DataAccess.Repository.Contract;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<EmployeeDto> GetEmployees()
        {
            var employees = _employeeRepository.GetEmployees();
            
            return employees.Select(e => _employeeFactory.Create(e));
        }

        public EmployeeDto GetEmployeeById(int employeeId)
        {
            var employee = _employeeRepository.GetEmployeeById(employeeId);
            
            return _employeeFactory.Create(employee);
        }
    }
}

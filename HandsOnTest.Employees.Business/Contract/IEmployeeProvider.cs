using HandsOnTest.Employees.Business.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandsOnTest.Employees.Business.Contract
{
    public interface IEmployeeProvider
    {
        IEnumerable<EmployeeDto> GetEmployees();

        EmployeeDto GetEmployeeById(int employeeId);
    }
}

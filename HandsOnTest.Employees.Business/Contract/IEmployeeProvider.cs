using HandsOnTest.Employees.Business.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandsOnTest.Employees.Business.Contract
{
    public interface IEmployeeProvider
    {
        Task<IEnumerable<EmployeeDto>> GetEmployees();

        Task<EmployeeDto> GetEmployeeById(int employeeId);
    }
}

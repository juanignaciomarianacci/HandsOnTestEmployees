using HandsOnTest.Employees.DataAccess.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandsOnTest.Employees.DataAccess.Repository.Contract
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> GetEmployeeById(int employeeId);
    }
}

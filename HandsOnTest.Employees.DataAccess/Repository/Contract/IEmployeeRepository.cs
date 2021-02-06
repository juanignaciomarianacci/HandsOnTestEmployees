using HandsOnTest.Employees.DataAccess.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandsOnTest.Employees.DataAccess.Repository.Contract
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();

        Employee GetEmployeeById(int employeeId);
    }
}

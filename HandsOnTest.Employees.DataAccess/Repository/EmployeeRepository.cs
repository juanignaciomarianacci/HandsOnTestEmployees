using HandsOnTest.Employees.DataAccess.Model;
using HandsOnTest.Employees.DataAccess.Repository.Contract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandsOnTest.Employees.DataAccess.Repository
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await GetAsync<IEnumerable<Employee>>("employees");
        }

        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            var employees = await GetAsync<IEnumerable<Employee>>("employees");

            return employees.Where(e => e.Id == employeeId).SingleOrDefault();
        }
    }
}

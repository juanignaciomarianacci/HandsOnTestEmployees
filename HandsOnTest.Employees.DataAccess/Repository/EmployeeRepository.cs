using HandsOnTest.Employees.DataAccess.Model;
using HandsOnTest.Employees.DataAccess.Repository.Contract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandsOnTest.Employees.DataAccess.Repository
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public IEnumerable<Employee> GetEmployees()
        {
            return GetAsync<IEnumerable<Employee>>("employees").Result;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return Task.Run(() => GetAsync<IEnumerable<Employee>>("employees"))
                .Result
                .Where(e => e.Id == employeeId)
                .SingleOrDefault();
        }
    }
}

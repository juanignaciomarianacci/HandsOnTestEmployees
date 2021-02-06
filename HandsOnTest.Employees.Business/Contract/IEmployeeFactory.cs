using HandsOnTest.Employees.Business.Dto;
using HandsOnTest.Employees.DataAccess.Model;

namespace HandsOnTest.Employees.Business.Contract
{
    public interface IEmployeeFactory
    {
        EmployeeDto Create(Employee employee);
    }
}

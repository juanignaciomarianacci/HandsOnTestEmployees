using HandsOnTest.Employees.Business.Contract;
using HandsOnTest.Employees.DataAccess.Model;

namespace HandsOnTest.Employees.Business
{
    public class HourlySalaryCalculator : ISalaryCalculator
    {
        public double Calculate(Employee employee)
        {
            return 120 * employee.HourlySalary * 12;
        }
    }
}

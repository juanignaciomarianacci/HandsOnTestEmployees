using HandsOnTest.Employees.Business.Contract;
using HandsOnTest.Employees.DataAccess.Model;

namespace HandsOnTest.Employees.Business
{
    public class MonthlySalaryCalculator : ISalaryCalculator
    {
        public double Calculate(Employee employee)
        {
            return employee.MonthlySalary * 12;
        }
    }
}

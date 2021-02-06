using HandsOnTest.Employees.DataAccess.Model;

namespace HandsOnTest.Employees.Business.Contract
{
    public interface ISalaryCalculator
    {
        double Calculate(Employee employee);
    }
}

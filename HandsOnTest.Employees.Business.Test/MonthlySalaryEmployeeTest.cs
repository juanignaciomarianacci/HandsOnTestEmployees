using HandsOnTest.Employees.Business.Contract;
using HandsOnTest.Employees.DataAccess.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HandsOnTest.Employees.Business.Test
{
    [TestClass]
    public class MonthlySalaryEmployeeTest
    {
        private ISalaryCalculator salaryCalculator = new MonthlySalaryCalculator();

        [TestMethod]
        public void WhenCalculate_ReturnsEmployeeSalary()
        {
            // Arrange
            double expectedSalary = 12000;
            var employee = new Employee
            {
                Id = 1,
                Name = "Test",
                MonthlySalary = 1000,
                HourlySalary = 3500
            };

            // Act
            var salary = salaryCalculator.Calculate(employee);

            // Assert
            Assert.AreEqual(salary, expectedSalary);
        }
    }
}

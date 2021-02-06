using HandsOnTest.Employees.Business.Contract;
using HandsOnTest.Employees.DataAccess.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HandsOnTest.Employees.Business.Test
{
    [TestClass]
    public class HourlySalaryCalculatorTest
    {
        private ISalaryCalculator salaryCalculator = new HourlySalaryCalculator();
        
        [TestMethod]
        public void WhenCalculate_ReturnsEmployeeSalary()
        {
            // Arrange
            double expectedSalary = 1440000;
            var employee = new Employee
            {
                Id = 1,
                Name = "Test",
                MonthlySalary = 3500,
                HourlySalary = 1000
            };

            // Act
            var salary = salaryCalculator.Calculate(employee);

            // Assert
            Assert.AreEqual(salary, expectedSalary);
        }
    }
}

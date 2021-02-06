using HandsOnTest.Employees.Business.Contract;
using HandsOnTest.Employees.DataAccess.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnTest.Employees.Business.Test
{
    [TestClass]
    public class EmployeeFactoryTest
    {
        private HourlySalaryCalculator hourlySalaryCalculator = new HourlySalaryCalculator();
        private MonthlySalaryCalculator monthlySalaryCalculator = new MonthlySalaryCalculator();
        private IEmployeeFactory employeeFactory;

        [TestMethod]
        [DataRow("HourlySalaryEmployee", 14400)]
        [DataRow("MonthlySalaryEmployee", 240)]
        public void WhenCalculate_Returns_Proper_EmployeeAnnualSalary(string contractTypeName, double expectedSalary)
        {
            // Arrange
            employeeFactory = new EmployeeFactory(hourlySalaryCalculator, monthlySalaryCalculator);

            var employee = new Employee
            {
                Id = 1,
                ContractTypeName = contractTypeName,
                Name = "Test Name",
                HourlySalary = 10,
                MonthlySalary = 20,
                RoleId = 1
            };

            // Act
            var salary = employeeFactory.Create(employee);

            // Assert
            Assert.AreEqual(salary.AnnualSalary, expectedSalary);
        }

        [TestMethod]
        public void WhenContractType_Not_Exists_ThrownException()
        {
            // Arrange
            employeeFactory = new EmployeeFactory(hourlySalaryCalculator, monthlySalaryCalculator);

            var employee = new Employee
            {
                Id = 1,
                ContractTypeName = "Test Contract Type",
                Name = "Test Name",
                HourlySalary = 10,
                MonthlySalary = 20,
                RoleId = 1
            };

            // Act - Assert
            Assert.ThrowsException<Exception>(() => employeeFactory.Create(employee));
        }
    }
}

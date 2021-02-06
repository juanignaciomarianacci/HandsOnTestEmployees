using HandsOnTest.Employees.Business.Constant;
using HandsOnTest.Employees.Business.Contract;
using HandsOnTest.Employees.Business.Dto;
using HandsOnTest.Employees.DataAccess.Model;
using System;
using System.Collections.Generic;

namespace HandsOnTest.Employees.Business
{
    public class EmployeeFactory : IEmployeeFactory
    {
        private readonly ISalaryCalculator _hourlySalaryCalculator;
        private readonly ISalaryCalculator _monthlySalaryCalculator;

        private readonly Dictionary<string, ISalaryCalculator> _operations;

        public EmployeeFactory(HourlySalaryCalculator _hourlySalaryCalculator, MonthlySalaryCalculator _monthlySalaryCalculator)
        {
            _operations = new Dictionary<string, ISalaryCalculator>()
                {
                    { ContractType.HourlySalaryEmployee, _hourlySalaryCalculator},
                    { ContractType.MonthlySalaryEmployee, _monthlySalaryCalculator}
                };
        }

        public EmployeeDto Create(Employee employee)
        {
            if (employee == null)
                return null;

            return new EmployeeDto
            {
                Id = employee.Id,
                ContractTypeName = employee.ContractTypeName,
                Name = employee.Name,
                RoleDescription = employee.RoleDescription,
                RoleId = employee.RoleId,
                RoleName = employee.RoleName,
                AnnualSalary = CalculateAnnualSalary(employee)
            };
        }

        private double CalculateAnnualSalary(Employee employee)
        {
            if(_operations.TryGetValue(employee.ContractTypeName, out ISalaryCalculator calculator))
            {
                return calculator.Calculate(employee);
            }

            throw new Exception("Contract type not found.");
        }
    }
}

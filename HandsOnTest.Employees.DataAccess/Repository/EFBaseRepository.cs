using HandsOnTest.Employees.DataAccess.Repository.Contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandsOnTest.Employees.DataAccess.Repository
{
    public class EFBaseRepository : IBaseRepository
    {
        private IList<dynamic> _employeesCollection;
        private IList<dynamic> _accountsCollection;

        private readonly Dictionary<string, IList<dynamic>> _repos;

        public EFBaseRepository()
        {
            _employeesCollection = new List<dynamic>() {
                new { Id = 1, ContractTypeName = "HourlySalaryEmployee", HourlySalary = 1, MonthlySalary = 1, Name = "Manuel" },
                new { Id = 2, ContractTypeName = "MonthlySalaryEmployee", HourlySalary = 1, MonthlySalary = 1, Name = "Jorge" },
                new { Id = 3, ContractTypeName = "HourlySalaryEmployee", HourlySalary = 1, MonthlySalary = 1, Name = "Andrés" }
            };
            _accountsCollection = new List<dynamic>();
            
            _repos = new Dictionary<string, IList<dynamic>>()
            {
                { "employees", _employeesCollection},
                { "accounts", _accountsCollection}
            }; 
        }

        public async Task<T> GetAsync<T>(string target)
        {
            if (_repos.TryGetValue(target, out IList<dynamic> repo))
            {
                var json = JsonConvert.SerializeObject(repo);
                var entities = JsonConvert.DeserializeObject<T>(json);

                return entities;
            }

            throw new Exception("Contract type not found.");
        }
    }
}

using System.Threading.Tasks;

namespace HandsOnTest.Employees.DataAccess.Repository.Contract
{
    public interface IBaseRepository
    {
        Task<T> GetAsync<T>(string target);
    }
}

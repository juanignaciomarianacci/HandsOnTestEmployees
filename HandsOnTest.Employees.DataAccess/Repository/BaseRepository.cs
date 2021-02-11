using HandsOnTest.Employees.DataAccess.Repository.Contract;
using System.Threading.Tasks;

namespace HandsOnTest.Employees.DataAccess.Repository
{
    public class BaseRepository
    {
        private readonly IBaseRepository _repository;

        public BaseRepository(IBaseRepository repository)
        {
            _repository = repository;
        }

        public Task<T> GetAsync<T>(string target)
        {
            return _repository.GetAsync<T>(target);
        }
    }
}

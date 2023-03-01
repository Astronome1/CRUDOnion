using Domain.Repositories;
using Microsoft.Extensions.Configuration;


namespace Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IUserCrudOperationsRepository>  _userCrudOperationsRepository;
       

        public RepositoryManager(IConfiguration configuration)
        {
            _userCrudOperationsRepository = new Lazy<IUserCrudOperationsRepository>(() => new UserCrudOperationsRepository(configuration));
        }
        public IUserCrudOperationsRepository UserCrudOperationsRepository => _userCrudOperationsRepository.Value;
    }
}

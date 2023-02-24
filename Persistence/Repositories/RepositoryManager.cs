using Domain.Repositories;
using Microsoft.Extensions.Configuration;


namespace Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IUserCrudOperationsRepository>  _userCrudOperationsRepository;
        //private readonly IConfiguration _configuration;

        public RepositoryManager(IConfiguration configuration)
        {
            //_configuration = configuration;
            _userCrudOperationsRepository = new Lazy<IUserCrudOperationsRepository>(() => new UserCrudOperationsRepository(configuration));
        }
        public IUserCrudOperationsRepository UserCrudOperationsRepository => _userCrudOperationsRepository.Value;
    }
}

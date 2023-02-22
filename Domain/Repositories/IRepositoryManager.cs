

namespace Domain.Repositories
{
    public interface IRepositoryManager
    {
        IUserCrudOperationsRepository UserCrudOperationsRepository { get; }
    }
}

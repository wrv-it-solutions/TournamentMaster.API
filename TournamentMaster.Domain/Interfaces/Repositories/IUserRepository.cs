using TournamentMaster.Domain.Entities;

namespace TournamentMaster.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task AddAsync(User user);
    }
}

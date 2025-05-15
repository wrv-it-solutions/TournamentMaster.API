using Microsoft.EntityFrameworkCore;
using TournamentMaster.Domain.Entities;
using TournamentMaster.Domain.Interfaces.Repositories;

namespace TournamentMaster.Infrastructure.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TournamentDbContext _dbContext;

        public UserRepository(TournamentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            if (email is null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            return await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task AddAsync(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _dbContext.Users.Add(user);

            await _dbContext.SaveChangesAsync();
        }


    }
}

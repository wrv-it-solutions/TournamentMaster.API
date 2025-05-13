using TournamentMaster.Domain.Entities;

namespace TournamentMaster.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }

}

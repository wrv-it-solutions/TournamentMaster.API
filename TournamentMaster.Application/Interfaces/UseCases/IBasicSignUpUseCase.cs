using TournamentMaster.Application.DTOs;

namespace TournamentMaster.Application.Interfaces.UseCases
{
    public interface IBasicSignUpUseCase
    {
        public Task<BasicSignUpResponseDto> ExecuteAsync(BasicSignUpRequestDto request);
    }
}

using Microsoft.AspNetCore.Mvc;
using TournamentMaster.Application.DTOs;
using TournamentMaster.Application.Interfaces.UseCases;

namespace TournamentMaster.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IBasicSignUpUseCase _basicSignUpUseCase;

        public AuthController(IBasicSignUpUseCase basicSignUpUseCase)
        {
            _basicSignUpUseCase = basicSignUpUseCase;
        }

        [HttpPost("register")]
        public async Task<IActionResult> PostRegister(BasicSignUpRequestDto requestDto)
        {
            return Ok(await _basicSignUpUseCase.ExecuteAsync(requestDto));
        }
    }
}

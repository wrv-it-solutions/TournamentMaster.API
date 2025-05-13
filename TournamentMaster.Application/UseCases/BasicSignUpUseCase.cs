using Microsoft.Extensions.Logging;
using TournamentMaster.Application.DTOs;
using TournamentMaster.Application.Interfaces;
using TournamentMaster.Application.Interfaces.UseCases;
using TournamentMaster.Domain.Entities;
using TournamentMaster.Domain.Interfaces.Repositories;

namespace TournamentMaster.Application.UseCases
{
    public class BasicSignUpUseCase : IBasicSignUpUseCase
    {
        private readonly ILogger<BasicSignUpUseCase> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtGenerator;

        public BasicSignUpUseCase(
            ILogger<BasicSignUpUseCase> logger,
            IUserRepository userRepository,
            IJwtTokenGenerator jwtGenerator) 
        {
            _logger = logger;
            _userRepository = userRepository;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<BasicSignUpResponseDto> ExecuteAsync(BasicSignUpRequestDto request)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            
            if (existingUser != null)
                throw new Exception("Email already registered.");


            var user = new User
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                Email = request.Email,
                PasswordHash = request.Password,
            };

            await _userRepository.AddAsync(user);

            var token = _jwtGenerator.GenerateToken(user);

            return new BasicSignUpResponseDto
            {
                Id = user.Id,
                Email = user.Email,
                Message = "User registered successfully.",
                Token = token
            };
        }
    }
}

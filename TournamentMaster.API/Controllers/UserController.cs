using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TournamentMaster.Domain.Entities;
using TournamentMaster.Infrastructure.Database;

namespace TournamentMaster.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TournamentDbContext dbContext;

        public UserController(TournamentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post()
        {
            var user = new User
            {
                Email = "teste",
                MiddleName = "Test",
                FirstName = "Test",
                PasswordHash = "Test"
            };

            dbContext.Users.Add(user);  

            dbContext.SaveChanges();

            return Ok(user);
        }
    }
}

using InteriorDesign.Context;
using InteriorDesign.Entities;
using InteriorDesign.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InteriorDesign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly InteriorDesignDbContext _context;
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;
        private int? newUserId;

        public AuthController(ILogger<AuthController> logger, InteriorDesignDbContext context,
         IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
            _context = context;
        }
        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("Invalid Client Request");
                }

                // Search for the user in the
                //var dbUser = _unitOfWork.Repository.GetQueryable<User>().FirstOrDefault(
                //    u => u.Email == user.Email && u.Password == user.Password);

                // Assuming you have a DbContext instance named _context
                var dbUser = _context.Set<User>().FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);


                if (dbUser != null)
                {
                    //var role = _unitOfWork.Repository.GetQueryable<Role>().Where(m => m.Id == dbUser.RoleId).FirstOrDefault();
                    var token = _authService.GenerateJwtToken(user);
                    // Map the dbUser object to a UserDTO object
                    //var userDTO = new UserDTO
                    //{
                    //    Id = dbUser.Id,
                    //    Username = dbUser.Username,
                    //    Email = dbUser.Email,
                    //    RoleId = dbUser.RoleId,
                    //    Role = role.RoleName,
                    //    CompanyId = role.CompanyId
                    //};User = userDTO

                    return Ok(new { Token = token, dbUser});
                }
                else
                {
                    return Unauthorized();
                    /*return Task.FromResult<IActionResult>(BadRequest("Invalid login attempt."));*/
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error logging in user: {ex.Message}");
            }
        }
        // GET: api/<AuthController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuthController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AuthController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

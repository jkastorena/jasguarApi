using jasguarApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace jasguarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly JasguarContext _jasguarContext;
        public UserController(JasguarContext jasguarContext){
            _jasguarContext = jasguarContext;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddUser(User user){

            user.EncryptPw();
            user.AddSalt();

            _jasguarContext.Users.Add(user);
            await _jasguarContext.SaveChangesAsync();

            return Ok(user);    
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers(){
            var Users = await _jasguarContext.Users.ToListAsync();

            return Ok( Users);
        }

    }
}

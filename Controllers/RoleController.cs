using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace jasguarApi;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{

    private readonly JasguarContext _jasguarContext;

    public RoleController(JasguarContext context) {
        _jasguarContext = context;
    }


    [HttpPost]
    public async Task<IActionResult> AddRole(Role role){
        if (role == null) return BadRequest("");

        _jasguarContext.Roles.Add(role);
        await _jasguarContext.SaveChangesAsync();
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetRoles(){

        var Roles = await _jasguarContext.Roles.ToListAsync();

        return Ok(Roles);
    }
}

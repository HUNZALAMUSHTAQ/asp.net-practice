using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using superhero.Models;

namespace superhero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase
    {
        private readonly UserContext _users;
        public Users(UserContext userContext )
        {
            this._users = userContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return _users.Users.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUsersById(int id)
        {
            var cuser = _users.Users.Where(x => x.Id == id).FirstOrDefault();
            if(cuser != null )
            {
                return cuser;
            } else { return NotFound(); }
        }
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user) 
        {
            var createdUser =  _users.Users.Add(user);
            Console.WriteLine(createdUser);
            _users.SaveChanges();
            return Ok(createdUser);
        }
        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser(User user)
        {
            _users.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _users.SaveChangesAsync();
            return Ok(user);
        }
        [HttpDelete]
        public async Task<ActionResult<User>> DeleteUser(User user)
        {
            var cuser = _users.Users.Where(x => x.Id == user.Id).FirstOrDefault();
            if (cuser != null)
            {
                _users.Remove(user);
                _users.SaveChanges();
                return Ok(user);
            }
            else { return NotFound(); }

        }


    }
}

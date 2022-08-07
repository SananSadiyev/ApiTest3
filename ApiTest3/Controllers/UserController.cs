
using DataAcces;
using DataAcces.BseEntities;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTest3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        protected readonly IUserServices _userservices;

        public UserController(IUserServices userservices)
        {
            _userservices = userservices;
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var res = _userservices.Get(id);
                if (res == null)
                {
                    return NotFound();
                }
                return Ok(res);
            }

            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }

        [HttpGet]
        [Route("Get")]
        public IEnumerable<UserDTO> Get()
        {
            return _userservices.Get();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete([FromRoute] int id)
        {
            _userservices.Delete(id);

        }

        [HttpPut]
        [Route("Update")]
        public UserDTO Update([FromBody] UserDTO user)
        {
            return _userservices.Update(user);
        }

        [HttpPost]
        [Route("Create")]
        public UserDTO Create([FromBody] UserDTO user)
        {
            return _userservices.Create(user);
        }

        [HttpGet]
        [Route("GetContact")]
        public IEnumerable<UserContactsDTO> GetUserContast()
        {
            return _userservices.GetUserContasts();
        }

    }
}


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
    public class UserRoleController : ControllerBase
    {
        protected readonly IUserRoleServices _UserRoleservices;

        public UserRoleController(IUserRoleServices UserRoleservices)
        {
            _UserRoleservices = UserRoleservices;
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var res = _UserRoleservices.Get(id);
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
        public IEnumerable<UserRoleDTO> Get()
        {
            return _UserRoleservices.Get();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete([FromRoute] int id)
        {
            _UserRoleservices.Delete(id);

        }

        [HttpPut]
        [Route("Update")]
        public UserRoleDTO Update([FromBody] UserRoleDTO UserRole)
        {
            return _UserRoleservices.Update(UserRole);
        }

        [HttpPost]
        [Route("Create")]
        public UserRoleDTO Create([FromBody] UserRoleDTO UserRole)
        {
            return _UserRoleservices.Create(UserRole);
        }

        //[HttpGet]
        //[Route("GetContact")]
        //public IEnumerable<UserRoleContactsDTO> GetUserRoleContast()
        //{
        //    return _UserRoleservices.GetUserRoleContasts();
        //}

    }
}

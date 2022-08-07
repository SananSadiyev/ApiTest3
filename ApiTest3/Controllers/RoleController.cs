
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
    public class RoleController : ControllerBase
    {
        protected readonly IRoleServices _Roleservices;

        public RoleController(IRoleServices Roleservices)
        {
            _Roleservices = Roleservices;
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try 
            {
                var res = _Roleservices.Get(id);
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
        public IEnumerable<RoleDTO> Get()
        {
            return _Roleservices.Get();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete([FromRoute] int id)
        {
            _Roleservices.Delete(id);

        }

        [HttpPut]
        [Route("Update")]
        public RoleDTO Update([FromBody] RoleDTO Role)
        {
            return _Roleservices.Update(Role);
        }

        [HttpPost]
        [Route("Create")]
        public RoleDTO Create([FromBody] RoleDTO Role)
        {
            return _Roleservices.Create(Role);
        }

        //[HttpGet]
        //[Route("GetContact")]
        //public IEnumerable<RoleContactsDTO> GetRoleContast()
        //{
        //    return _Roleservices.GetRoleContasts();
        //}

    }
}

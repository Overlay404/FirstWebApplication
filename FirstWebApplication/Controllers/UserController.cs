using FirstWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstWebApplication.Controllers
{
    public class UserController : ApiController
    {
        ClientSimulatorEntities db = new ClientSimulatorEntities();

        [HttpGet]
        [Route("Users/GetAllUsers")]
        public IHttpActionResult GetAllUser()
        {
            return Ok(db.Client.ToList());
        }


        [HttpGet]
        [Route("Users/{name}")]
        public IHttpActionResult GetUser(string name)
        {
            var request = db.Client.Where(c => c.Surname.Equals(name));

            if (request != null)
                return Ok(db.Client.Where(c => c.Surname.Equals(name)));
            else
                return BadRequest("Запрос неуданый, пользователя с тауим именем не существует");
        }

        [HttpGet]
        [Route("Realtors/GetAllRealtors")]
        public IHttpActionResult GetAllRealtors()
        {
            return Ok(db.Realtor.ToList());
        }


        [HttpGet]
        [Route("Realtors/{name}")]
        public IHttpActionResult GetRealtor(string name)
        {
            var request = db.Realtor.Where(c => c.Surname.Equals(name));

            if (request != null)
                return Ok(db.Realtor.Where(c => c.Surname.Equals(name)));
            else
                return BadRequest("Запрос неуданый, пользователя с тауим именем не существует");
        }

    }
}

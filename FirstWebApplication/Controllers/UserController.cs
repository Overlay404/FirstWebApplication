using FirstWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        [HttpPost]
        [Route("Realtors/Add")]
        public IHttpActionResult NewRealtor(Realtor realtor)
        {
            Debug.WriteLine("Пусто");
            if (realtor == null) return Ok();

            db.Realtor.Add(realtor);
            db.SaveChanges();
            Debug.WriteLine(realtor.Name);
            return Ok();
        }

        [HttpPost]
        [Route("Clients/Add")]
        public IHttpActionResult NewClient(Client client)
        {
            Debug.WriteLine("Пусто");
            if (client == null) return Ok();

            db.Client.Add(client);
            db.SaveChanges();
            Debug.WriteLine(client.Name);
            return Ok();
        }

        [HttpDelete]
        [Route("Clients/Delete/{id}")]
        public IHttpActionResult DeleteClient(int id)
        {
            var request = db.Client.Where(c => c.Id == id).FirstOrDefault();

            if (request != null)
            {
                db.Client.Remove(request);
                db.SaveChanges();
                return Ok();
            }
            else
                return BadRequest("Запрос неуданый, пользователя с тауим именем не существует");
        }

        [HttpDelete]
        [Route("Realtors/Delete/{id}")]
        public IHttpActionResult DeleteRealtor(int id)
        {
            var request = db.Realtor.Where(c => c.Id == id).FirstOrDefault();

            if (request != null)
            {
                db.Realtor.Remove(request);
                db.SaveChanges();
                return Ok();
            }
            else
                return BadRequest("Запрос неуданый, пользователя с тауим именем не существует");
        }
    }
}

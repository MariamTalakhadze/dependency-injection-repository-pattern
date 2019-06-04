using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BL;
using DataAccessLayer;
using Models;

namespace PWebApi.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        // GET: User
        readonly userlogics logic;
        public UserController(userlogics logic)
        {
            this.logic = logic;
        }

        [HttpGet, Route("App/users")]
        public IHttpActionResult Get()
        {
            List<DataAccessLayer.userinfo> result = logic.getAllUsers().ToList();
            IList<Models.UserModel> users = Mapper.Map<List<DataAccessLayer.userinfo>, List<Models.UserModel>>(result);
            if (users.Count == 0)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            Models.UserModel users = Mapper.Map<DataAccessLayer.userinfo, Models.UserModel>(logic.findUsers(id));
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpPost, Route("")]
        public IHttpActionResult Post([FromBody]Models.UserModel user)
        {
            DataAccessLayer.userinfo a = Mapper.Map<Models.UserModel, DataAccessLayer.userinfo>(user);
            bool success = logic.addUsers(a);
            if (success)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Invalid data");
            }
        }

        [HttpPut, Route("")]
        public IHttpActionResult Put([FromBody]DataAccessLayer.userinfo user)
        {
            bool success = logic.updateUsers(user);
            if (success)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Invalid data");
            }
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            bool success = logic.deleteUsers(id);
            if (success)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Invalid data");
            }
        }
    }
}
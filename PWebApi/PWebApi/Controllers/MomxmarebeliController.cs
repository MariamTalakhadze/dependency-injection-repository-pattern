using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BL;
using DataAccessLayer;
using Models;

namespace PWebApi.Controllers
{
    [RoutePrefix("api/Momxmarebeli")]
    public class MomxmarebeliController : ApiController
    {
        readonly MomxmarebeliLogics logic;
        public MomxmarebeliController(MomxmarebeliLogics logic)
        {
            this.logic = logic;
        }

        [HttpGet, Route("App/Momxmarebeli")]
        public IHttpActionResult Get()
        {
            List<DataAccessLayer.Momxmarebeli> result = logic.getAllMomxmarebeli().ToList();
            IList<Models.MomxmarebeliModels> momxmarebeli = Mapper.Map<List<DataAccessLayer.Momxmarebeli>, List<Models.MomxmarebeliModels>>(result);
            if (momxmarebeli.Count == 0)
            {
                return NotFound();
            }
            return Ok(momxmarebeli);
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            Models.MomxmarebeliModels momxmarebeli = Mapper.Map<DataAccessLayer.Momxmarebeli, Models.MomxmarebeliModels>(logic.findMomxmarebeli(id));
            if (momxmarebeli == null)
            {
                return NotFound();
            }

            return Ok(momxmarebeli);
        }

        [HttpPost, Route("")]
        public IHttpActionResult Post([FromBody]Models.MomxmarebeliModels momxmarebeli)
        {
            DataAccessLayer.Momxmarebeli a = Mapper.Map<Models.MomxmarebeliModels, DataAccessLayer.Momxmarebeli>(momxmarebeli);
            bool success = logic.addMomxmarebeli(a);
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
        public IHttpActionResult Put([FromBody]DataAccessLayer.Momxmarebeli momxmarebeli)
        {
            bool success = logic.updateMomxmarebeli(momxmarebeli);
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
            bool success = logic.deleteMomxmarebeli(id);
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
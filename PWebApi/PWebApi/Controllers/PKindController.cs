using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BL;
using DataAccessLayer;
using Models;

namespace PWebApi.Controllers
{
    [RoutePrefix("api/kind")]
    public class PKindController : ApiController
    {
        // GET: User
        readonly KindLogics logic;
        public PKindController(KindLogics logic)
        {
            this.logic = logic;
        }

        [HttpGet, Route("App/kind")]
        public IHttpActionResult Get()
        {
            List<DataAccessLayer.pkind> result = logic.getAllKind().ToList();
            IList<Models.Pkindmodel> kind = Mapper.Map<List<DataAccessLayer.pkind>, List<Models.Pkindmodel>>(result);
            if (kind.Count == 0)
            {
                return NotFound();
            }
            return Ok(kind);
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            Models.Pkindmodel kind = Mapper.Map<DataAccessLayer.pkind, Models.Pkindmodel>(logic.findkind(id));
            if (kind == null)
            {
                return NotFound();
            }

            return Ok(kind);
        }

        [HttpPost, Route("")]
        public IHttpActionResult Post([FromBody]Models.Pkindmodel kind)
        {
            DataAccessLayer.pkind a = Mapper.Map<Models.Pkindmodel, DataAccessLayer.pkind>(kind);
            bool success = logic.addKind(a);
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
        public IHttpActionResult Put([FromBody]DataAccessLayer.pkind kind)
        {
            bool success = logic.updatekinds(kind);
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
            bool success = logic.deletekinds(id);
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
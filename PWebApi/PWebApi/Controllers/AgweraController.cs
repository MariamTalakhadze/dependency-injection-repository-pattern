using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BL;
using DataAccessLayer;
using Models;

namespace PWebApi.Controllers
{
    [RoutePrefix("api/Agwera")]
    public class AgweraController : ApiController
    {
        readonly AgweraLogics logic;
        public AgweraController(AgweraLogics logic)
        {
            this.logic = logic;
        }

        [HttpGet, Route("App/Agwera")]
        public IHttpActionResult Get()
        {
            List<DataAccessLayer.Agwera> result = logic.getAllAgwera().ToList();
            IList<Models.AgweraModels> agwera = Mapper.Map<List<DataAccessLayer.Agwera>, List<Models.AgweraModels>>(result);
            if (agwera.Count == 0)
            {
                return NotFound();
            }
            return Ok(agwera);
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            Models.AgweraModels agwera = Mapper.Map<DataAccessLayer.Agwera, Models.AgweraModels> (logic.findAgwera(id));
            if (agwera == null)
            {
                return NotFound();
            }

            return Ok(agwera);
        }

        [HttpPost, Route("")]
        public IHttpActionResult Post([FromBody]Models.AgweraModels agwera)
        {
            DataAccessLayer.Agwera a = Mapper.Map<Models.AgweraModels , DataAccessLayer.Agwera>(agwera);
            bool success = logic.addAgwera(a);
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
        public IHttpActionResult Put([FromBody]DataAccessLayer.Agwera agwera)
        {
            bool success = logic.updateAgwera(agwera);
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
            bool success = logic.deleteAgwera(id);
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
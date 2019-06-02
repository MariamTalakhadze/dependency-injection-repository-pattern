using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BL;
using DataAccessLayer;
using Models;

namespace PWebApi.Controllers
{
    [RoutePrefix("api/Shekvetebi")]
    public class ShekvetebiController : ApiController
    {
        readonly ShekvetebiLogics logic;
        public ShekvetebiController(ShekvetebiLogics logic)
        {
            this.logic = logic;
        }

        [HttpGet, Route("App/Shekvetebi")]
        public IHttpActionResult Get()
        {
            List<DataAccessLayer.Shekvetebi> result = logic.getAllShekvetebi().ToList();
            IList<Models.ShekvetebiModels> Shekvetebi = Mapper.Map<List<DataAccessLayer.Shekvetebi>, List<Models.ShekvetebiModels>>(result);
            if (Shekvetebi.Count == 0)
            {
                return NotFound();
            }
            return Ok(Shekvetebi);
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            Models.ShekvetebiModels Shekvetebi = Mapper.Map<DataAccessLayer.Shekvetebi, Models.ShekvetebiModels>(logic.findShekvetebi(id));
            if (Shekvetebi == null)
            {
                return NotFound();
            }

            return Ok(Shekvetebi);
        }

        [HttpPost, Route("")]
        public IHttpActionResult Post([FromBody]Models.ShekvetebiModels Shekvetebi)
        {
            DataAccessLayer.Shekvetebi a = Mapper.Map<Models.ShekvetebiModels, DataAccessLayer.Shekvetebi>(Shekvetebi);
            bool success = logic.addShekvetebi(a);
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
        public IHttpActionResult Put([FromBody]DataAccessLayer.Shekvetebi Shekvetebi)
        {
            bool success = logic.updateShekvetebi(Shekvetebi);
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
            bool success = logic.deleteShekvetebi(id);
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
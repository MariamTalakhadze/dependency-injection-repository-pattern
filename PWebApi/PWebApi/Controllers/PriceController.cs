using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BL;
using DataAccessLayer;
using Models;

namespace PWebApi.Controllers
{
    [RoutePrefix("api/price")]
    public class PriceController : ApiController
    {
        // GET: User
        readonly priceLogics logic;
        public PriceController(priceLogics logic)
        {
            this.logic = logic;
        }

        [HttpGet, Route("App/price")]
        public IHttpActionResult Get()
        {
            List<DataAccessLayer.PPrice> result = logic.getAllprice().ToList();
            IList<Models.PriceModel> price = Mapper.Map<List<DataAccessLayer.PPrice>, List<Models.PriceModel>>(result);
            if (price.Count == 0)
            {
                return NotFound();
            }
            return Ok(price);
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            Models.PriceModel price = Mapper.Map<DataAccessLayer.PPrice, Models.PriceModel>(logic.findprice(id));
            if (price == null)
            {
                return NotFound();
            }

            return Ok(price);
        }

        [HttpPost, Route("")]
        public IHttpActionResult Post([FromBody]Models.PriceModel price)
        {
            DataAccessLayer.PPrice a = Mapper.Map<Models.PriceModel, DataAccessLayer.PPrice>(price);
            bool success = logic.addPrice(a);
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
        public IHttpActionResult Put([FromBody]DataAccessLayer.PPrice price)
        {
            bool success = logic.updatePrice(price);
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
            bool success = logic.deletePrice(id);
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
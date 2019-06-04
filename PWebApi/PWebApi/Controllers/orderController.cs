using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BL;
using DataAccessLayer;
using Models;

namespace PWebApi.Controllers
{
    [RoutePrefix("api/order")]
    public class orderController : ApiController
    {
        // GET: User
        readonly orderLogics logic;
        public orderController(orderLogics logic)
        {
            this.logic = logic;
        }

        [HttpGet, Route("App/order")]
        public IHttpActionResult Get()
        {
            List<DataAccessLayer.POrder> result = logic.getAllorder().ToList();
            IList<Models.OrderModel> order = Mapper.Map<List<DataAccessLayer.POrder>, List<Models.OrderModel>>(result);
            if (order.Count == 0)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            Models.OrderModel order = Mapper.Map<DataAccessLayer.POrder, Models.OrderModel>(logic.findorder(id));
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost, Route("")]
        public IHttpActionResult Post([FromBody]Models.OrderModel order)
        {
            DataAccessLayer.POrder a = Mapper.Map<Models.OrderModel, DataAccessLayer.POrder>(order);
            bool success = logic.addOrder(a);
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
        public IHttpActionResult Put([FromBody]DataAccessLayer.POrder order)
        {
            bool success = logic.updateorders(order);
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
            bool success = logic.deleteorders(id);
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
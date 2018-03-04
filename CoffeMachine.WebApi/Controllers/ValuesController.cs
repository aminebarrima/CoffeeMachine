using CoffeeMachine.GetWay;
using CoffeeMachine.GetWay.Infrastructure;
using CoffeeMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoffeMachine.WebApi.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Boisson> Get()
        {

            CoffeeMachineDbContext cntx = new CoffeeMachineDbContext();
            UnitOfWork _unitOfWork = new UnitOfWork(cntx);
            var boisson = _unitOfWork.Repository<Boisson>();
            return boisson.GetAll().ToList();

            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

using CoffeeMachine.GetWay.Infrastructure;
using CoffeeMachine.Models;
using CoffeeMachine.Web_API.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CoffeeMachine.Web_API.Controllers
{
   // [MyCorsPolicyAttribute]
   // [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BoissonsController : ApiController
    {

        private readonly IUnitOfWork _unitOfWork;
        public BoissonsController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        // GET: api/Boissons
        [HttpGet]
        [Route("api/Boissons")]
        public IHttpActionResult GetBoisson()
        {

            var boissonRepository = _unitOfWork.Repository<Boisson>();
            var Boissons = boissonRepository.GetAll().ToList();
            if (Boissons != null)
                return Ok(Boissons);
            else
                return NotFound();
        }


    }
}

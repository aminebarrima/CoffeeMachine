using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CoffeeMachine.Models;
using CoffeeMachine.GetWay.Infrastructure;
using System;

namespace CoffeMachine.WebApi.Controllers
{
    [Authorize]
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
        public IEnumerable<Boisson> GetBoisson()
        {
           
            var boissonRepository = _unitOfWork.Repository<Boisson>();
            return boissonRepository.GetAll().ToList();
             
        }

        
    }
}
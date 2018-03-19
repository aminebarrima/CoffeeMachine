using CoffeeMachine.GetWay.Infrastructure;
using CoffeeMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoffeeMachine.Web_API.Controllers
{
    public class BadgesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public BadgesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: api/Badges
        [HttpGet]
        [Route("api/Badges")]
        public IHttpActionResult GetBadge()
        {
            var Badges = _unitOfWork.Repository<Badge>().GetAll().ToList();
            if (Badges != null)
                return Ok(Badges);
            else
                return NotFound();

        }


    }
}

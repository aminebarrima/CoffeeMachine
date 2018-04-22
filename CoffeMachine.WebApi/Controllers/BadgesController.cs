using System.Linq;
using System.Web.Http;
using CoffeeMachine.Models;
using CoffeeMachine.GetWay.Infrastructure;
namespace CoffeMachine.WebApi.Controllers
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
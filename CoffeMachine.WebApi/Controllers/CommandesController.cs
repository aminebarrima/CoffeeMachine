using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Http;
using CoffeeMachine.Models;
using CoffeeMachine.GetWay.Infrastructure;
namespace CoffeMachine.WebApi.Controllers
{
    [Authorize]
    public class CommandesController : ApiController
    {

        private readonly IUnitOfWork _unitOfWork;
        public CommandesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        //test


        [HttpGet]
        [Route("api/Commandes/{badgeId}")]
        public IHttpActionResult getMemoeryCommandeByBadge(int badgeId)
        {
            var commandeRepository = _unitOfWork.Repository<Commande>();
            var commande = commandeRepository
                .FindBy(c => c.badgeId == badgeId && c.memoeryFlage == true)
                .OrderByDescending(o => o.dateCommande)
                .FirstOrDefault();
            if (commande != null)
                return Ok(commande);
            else
                return NotFound();
        }


        [HttpPost]
        [Route("api/Commandes")]
        public IHttpActionResult PostCommande(Commande commande)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var commandeRepository = _unitOfWork.Repository<Commande>();
                commandeRepository.Add(commande);
                _unitOfWork.SaveChanges();
                return Ok(commande.commandeId);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: commande not created :" + ex.Message);
            }


            //return StatusCode(HttpStatusCode.NoContent);
        }


    }
}
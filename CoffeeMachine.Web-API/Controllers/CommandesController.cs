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
    public class CommandesController : ApiController
    {

        private readonly IUnitOfWork _unitOfWork;
        public CommandesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



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


            return StatusCode(HttpStatusCode.NoContent);
        }


    }
}

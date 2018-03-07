using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CoffeeMachine.GetWay;
using CoffeeMachine.Models;
using CoffeeMachine.GetWay.Infrastructure;

namespace CoffeMachine.WebApi.Controllers
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
                .FindBy(c => c.badgeId== badgeId && c.memoeryFlage==true)
                .OrderByDescending(o => o.dateCommande)
                .FirstOrDefault();

            if (commande != null)
                return Ok(commande);
            else
                return NotFound();
           

        }
        //// GET: api/Commandes
        //public IQueryable<Commande> GetCommande()
        //{
        //    return db.Commande;
        //}

        //// GET: api/Commandes/5
        //[ResponseType(typeof(Commande))]
        //public IHttpActionResult GetCommande(int id)
        //{
        //    Commande commande = db.Commande.Find(id);
        //    if (commande == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(commande);
        //}

        //// PUT: api/Commandes/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCommande(int id, Commande commande)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != commande.commandeId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(commande).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CommandeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Commandes


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
            }
            catch (Exception ex)
            { 
                return BadRequest("Error: commande not created :"+ex.Message);
            }
            return Ok(commande.commandeId);

            //var repositorybadge = _unitOfWork.Repository<Badge>();
            //var badge = new Badge();
            //badge.keyBadge = commande.badge.keyBadge;
            //repositorybadge.Add(badge);
            //_unitOfWork.SaveChanges();
            //commande.badgeId = badge.badgeId;
            //return CreatedAtRoute("DefaultApi", new { id = commande.commandeId }, commande);
        }

        //// DELETE: api/Commandes/5
        //[ResponseType(typeof(Commande))]
        //public IHttpActionResult DeleteCommande(int id)
        //{
        //    Commande commande = db.Commande.Find(id);
        //    if (commande == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Commande.Remove(commande);
        //    db.SaveChanges();

        //    return Ok(commande);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool CommandeExists(int id)
        //{
        //    return db.Commande.Count(e => e.commandeId == id) > 0;
        //}
    }
}
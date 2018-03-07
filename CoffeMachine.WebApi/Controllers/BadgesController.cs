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
        public IEnumerable<Badge> GetBadge()
        {
            var badgeRepository = _unitOfWork.Repository<Badge>();
            return badgeRepository.GetAll().ToList();

        }

        //// GET: api/Badges/5
        //[ResponseType(typeof(Badge))]
        //public IHttpActionResult GetBadge(int id)
        //{
        //    Badge badge = db.Badge.Find(id);
        //    if (badge == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(badge);
        //}

        //// PUT: api/Badges/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutBadge(int id, Badge badge)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != badge.badgeId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(badge).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BadgeExists(id))
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

        //// POST: api/Badges
        //[ResponseType(typeof(Badge))]
        //public IHttpActionResult PostBadge(Badge badge)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Badge.Add(badge);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = badge.badgeId }, badge);
        //}

        //// DELETE: api/Badges/5
        //[ResponseType(typeof(Badge))]
        //public IHttpActionResult DeleteBadge(int id)
        //{
        //    Badge badge = db.Badge.Find(id);
        //    if (badge == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Badge.Remove(badge);
        //    db.SaveChanges();

        //    return Ok(badge);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool BadgeExists(int id)
        //{
        //    return db.Badge.Count(e => e.badgeId == id) > 0;
        //}
    }
}
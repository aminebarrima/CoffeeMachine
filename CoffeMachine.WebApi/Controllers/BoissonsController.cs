using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CoffeeMachine.Models;
using CoffeeMachine.GetWay.Infrastructure;
namespace CoffeMachine.WebApi.Controllers
{
    public class BoissonsController : ApiController
    {
       
        private readonly IUnitOfWork _unitOfWork;
        public BoissonsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Boissons
        public IEnumerable<Boisson> GetBoisson()
        { 
           
            var boisson = _unitOfWork.Repository<Boisson>();
            return boisson.GetAll().ToList();
           
        }

        //// GET: api/Boissons/5
        //[ResponseType(typeof(Boisson))]
        //public IHttpActionResult GetBoisson(int id)
        //{
        //    Boisson boisson = cntx.Boisson.Find(id);
        //    if (boisson == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(boisson);
        //}

        //// PUT: api/Boissons/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutBoisson(int id, Boisson boisson)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != boisson.boissonId)
        //    {
        //        return BadRequest();
        //    }

        //    cntx.Entry(boisson).State = EntityState.Modified;

        //    try
        //    {
        //        cntx.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BoissonExists(id))
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

        //// POST: api/Boissons
        //[ResponseType(typeof(Boisson))]
        //public IHttpActionResult PostBoisson(Boisson boisson)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    cntx.Boisson.Add(boisson);
        //    cntx.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = boisson.boissonId }, boisson);
        //}

        //// DELETE: api/Boissons/5
        //[ResponseType(typeof(Boisson))]
        //public IHttpActionResult DeleteBoisson(int id)
        //{
        //    Boisson boisson = cntx.Boisson.Find(id);
        //    if (boisson == null)
        //    {
        //        return NotFound();
        //    }

        //    cntx.Boisson.Remove(boisson);
        //    cntx.SaveChanges();

        //    return Ok(boisson);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        cntx.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool BoissonExists(int id)
        //{
        //    return cntx.Boisson.Count(e => e.boissonId == id) > 0;
        //}
    }
}
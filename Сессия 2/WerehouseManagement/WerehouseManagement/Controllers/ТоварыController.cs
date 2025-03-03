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
using WerehouseManagement;
using WerehouseManagement.Models;

namespace WerehouseManagement.Controllers
{
    public class ТоварыController : ApiController
    {
        private Складской_учетEntities db = new Складской_учетEntities();


        // GET: api/Товары
        [ResponseType(typeof(List<Товары>))]
        public IHttpActionResult GetТовары()
        {
            return Ok(db.Товары.ToList().ConvertAll(p => new Товар(p)));
        }
        // GET: api/Товары
       /* public IQueryable<Товары> GetТовары()
        {
            return db.Товары;
        }*/

        // GET: api/Товары/5
        [ResponseType(typeof(Товары))]
        public IHttpActionResult GetТовары(int id)
        {
            Товары товары = db.Товары.Find(id);
            if (товары == null)
            {
                return NotFound();
            }

            return Ok(товары);
        }

        // PUT: api/Товары/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutТовары(int id, Товары товары)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != товары.ID_Товара)
            {
                return BadRequest();
            }

            db.Entry(товары).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ТоварыExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Товары
        [ResponseType(typeof(Товары))]
        public IHttpActionResult PostТовары(Товары товары)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Товары.Add(товары);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = товары.ID_Товара }, товары);
        }

        // DELETE: api/Товары/5
        [ResponseType(typeof(Товары))]
        public IHttpActionResult DeleteТовары(int id)
        {
            Товары товары = db.Товары.Find(id);
            if (товары == null)
            {
                return NotFound();
            }

            db.Товары.Remove(товары);
            db.SaveChanges();

            return Ok(товары);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ТоварыExists(int id)
        {
            return db.Товары.Count(e => e.ID_Товара == id) > 0;
        }
    }
}
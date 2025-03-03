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
using LibWarehouse;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WerehouseManagement.Controllers
{
    public class СкладыController : ApiController
    {
        private Складской_учетEntities db = new Складской_учетEntities();

        // GET: api/Склады
        public IQueryable<Склады> GetСклады()
        {
            return db.Склады;
        }

        // GET: api/Склады/5
        [ResponseType(typeof(Склады))]
        public IHttpActionResult GetСклады(int id)
        {
            Склады склады = db.Склады.Find(id);
            if (склады == null)
            {
                return NotFound();
            }

            return Ok(склады);
        }

        // PUT: api/Склады/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutСклады(int id, Склады склады)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != склады.ID_Склада)
            {
                return BadRequest();
            }

            db.Entry(склады).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!СкладыExists(id))
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

        // POST: api/Склады
        [ResponseType(typeof(Склады))]
        public IHttpActionResult PostСклады(Склады склады)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Склады.Add(склады);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = склады.ID_Склада }, склады);
        }

        // DELETE: api/Склады/5
        [ResponseType(typeof(Склады))]
        public IHttpActionResult DeleteСклады(int id)
        {
            Склады склады = db.Склады.Find(id);
            if (склады == null)
            {
                return NotFound();
            }

            db.Склады.Remove(склады);
            db.SaveChanges();

            return Ok(склады);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool СкладыExists(int id)
        {
            return db.Склады.Count(e => e.ID_Склада == id) > 0;
        }
      /*  private readonly HttpClient _httpClient;

        public СкладыController()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: api/Склады/Остатки/Из_API
        public async Task<IHttpActionResult> GetОстаткиИзAPI()
        {
            var response = await _httpClient.GetAsync("https://example.com/api/остатки");
            if (response.IsSuccessStatusCode)
            {
                var остатки = await response.Content.ReadAsAsync<List<Остатки_На_Складе>>();
                var анализатор = new СкладскойАнализатор();
                var общее_количество = анализатор.ПодсчитатьОбщееКоличество(остатки);

                return Ok(new { Общее_количество = общее_количество });
            }
            else
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }*/
    }


}
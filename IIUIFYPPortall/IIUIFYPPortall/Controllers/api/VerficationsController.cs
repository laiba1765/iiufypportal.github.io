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
using IIUIFYPPortall.Models;

namespace IIUIFYPPortall.Controllers.api
{
    public class VerficationsController : ApiController
    {
        private Database1Entities db = new Database1Entities();

        // GET: api/Verfications
        public IQueryable<Verfication> GetVerfications()
        {
            return db.Verfications;
        }

        // GET: api/Verfications/5
        [ResponseType(typeof(Verfication))]
        public IHttpActionResult GetVerfication(int id)
        {
            Verfication verfication = db.Verfications.Find(id);
            if (verfication == null)
            {
                return NotFound();
            }

            return Ok(verfication);
        }

        // PUT: api/Verfications/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVerfication(int id, Verfication verfication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != verfication.Id)
            {
                return BadRequest();
            }

            db.Entry(verfication).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VerficationExists(id))
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

        // POST: api/Verfications
        [ResponseType(typeof(Verfication))]
        public IHttpActionResult PostVerfication(Verfication verfication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Verfications.Add(verfication);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = verfication.Id }, verfication);
        }

        // DELETE: api/Verfications/5
        [ResponseType(typeof(Verfication))]
        public IHttpActionResult DeleteVerfication(int id)
        {
            Verfication verfication = db.Verfications.Find(id);
            if (verfication == null)
            {
                return NotFound();
            }

            db.Verfications.Remove(verfication);
            db.SaveChanges();

            return Ok(verfication);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VerficationExists(int id)
        {
            return db.Verfications.Count(e => e.Id == id) > 0;
        }
    }
}
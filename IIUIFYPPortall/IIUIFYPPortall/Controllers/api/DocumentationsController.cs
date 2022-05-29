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
    public class DocumentationsController : ApiController
    {
        private Database1Entities db = new Database1Entities();

        // GET: api/Documentations
        public IQueryable<Documentation> GetDocumentations()
        {
            return db.Documentations;
        }

        // GET: api/Documentations/5
        [ResponseType(typeof(Documentation))]
        public IHttpActionResult GetDocumentation(int id)
        {
            Documentation documentation = db.Documentations.Find(id);
            if (documentation == null)
            {
                return NotFound();
            }

            return Ok(documentation);
        }

        // PUT: api/Documentations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDocumentation(int id, Documentation documentation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != documentation.Id)
            {
                return BadRequest();
            }

            db.Entry(documentation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentationExists(id))
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

        // POST: api/Documentations
        [ResponseType(typeof(Documentation))]
        public IHttpActionResult PostDocumentation(Documentation documentation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Documentations.Add(documentation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = documentation.Id }, documentation);
        }

        // DELETE: api/Documentations/5
        [ResponseType(typeof(Documentation))]
        public IHttpActionResult DeleteDocumentation(int id)
        {
            Documentation documentation = db.Documentations.Find(id);
            if (documentation == null)
            {
                return NotFound();
            }

            db.Documentations.Remove(documentation);
            db.SaveChanges();

            return Ok(documentation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DocumentationExists(int id)
        {
            return db.Documentations.Count(e => e.Id == id) > 0;
        }
    }
}
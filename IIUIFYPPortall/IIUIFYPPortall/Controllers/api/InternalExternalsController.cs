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
    public class InternalExternalsController : ApiController
    {
        private Database1Entities db = new Database1Entities();

        // GET: api/InternalExternals
        public IQueryable<InternalExternal> GetInternalExternals()
        {
            return db.InternalExternals;
        }

        // GET: api/InternalExternals/5
        [ResponseType(typeof(InternalExternal))]
        public IHttpActionResult GetInternalExternal(int id)
        {
            InternalExternal internalExternal = db.InternalExternals.Find(id);
            if (internalExternal == null)
            {
                return NotFound();
            }

            return Ok(internalExternal);
        }

        // PUT: api/InternalExternals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInternalExternal(int id, InternalExternal internalExternal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != internalExternal.Id)
            {
                return BadRequest();
            }

            db.Entry(internalExternal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InternalExternalExists(id))
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

        // POST: api/InternalExternals
        [ResponseType(typeof(InternalExternal))]
        public IHttpActionResult PostInternalExternal(InternalExternal internalExternal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InternalExternals.Add(internalExternal);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = internalExternal.Id }, internalExternal);
        }

        // DELETE: api/InternalExternals/5
        [ResponseType(typeof(InternalExternal))]
        public IHttpActionResult DeleteInternalExternal(int id)
        {
            InternalExternal internalExternal = db.InternalExternals.Find(id);
            if (internalExternal == null)
            {
                return NotFound();
            }

            db.InternalExternals.Remove(internalExternal);
            db.SaveChanges();

            return Ok(internalExternal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InternalExternalExists(int id)
        {
            return db.InternalExternals.Count(e => e.Id == id) > 0;
        }
    }
}
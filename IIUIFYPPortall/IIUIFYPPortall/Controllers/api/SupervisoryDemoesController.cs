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
    public class SupervisoryDemoesController : ApiController
    {
        private Database1Entities db = new Database1Entities();

        // GET: api/SupervisoryDemoes
        public IQueryable<SupervisoryDemo> GetSupervisoryDemoes()
        {
            return db.SupervisoryDemoes;
        }

        // GET: api/SupervisoryDemoes/5
        [ResponseType(typeof(SupervisoryDemo))]
        public IHttpActionResult GetSupervisoryDemo(int id)
        {
            SupervisoryDemo supervisoryDemo = db.SupervisoryDemoes.Find(id);
            if (supervisoryDemo == null)
            {
                return NotFound();
            }

            return Ok(supervisoryDemo);
        }

        // PUT: api/SupervisoryDemoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSupervisoryDemo(int id, SupervisoryDemo supervisoryDemo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != supervisoryDemo.Id)
            {
                return BadRequest();
            }

            db.Entry(supervisoryDemo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupervisoryDemoExists(id))
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

        // POST: api/SupervisoryDemoes
        [ResponseType(typeof(SupervisoryDemo))]
        public IHttpActionResult PostSupervisoryDemo(SupervisoryDemo supervisoryDemo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SupervisoryDemoes.Add(supervisoryDemo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = supervisoryDemo.Id }, supervisoryDemo);
        }

        // DELETE: api/SupervisoryDemoes/5
        [ResponseType(typeof(SupervisoryDemo))]
        public IHttpActionResult DeleteSupervisoryDemo(int id)
        {
            SupervisoryDemo supervisoryDemo = db.SupervisoryDemoes.Find(id);
            if (supervisoryDemo == null)
            {
                return NotFound();
            }

            db.SupervisoryDemoes.Remove(supervisoryDemo);
            db.SaveChanges();

            return Ok(supervisoryDemo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SupervisoryDemoExists(int id)
        {
            return db.SupervisoryDemoes.Count(e => e.Id == id) > 0;
        }
    }
}
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
    public class PanelsController : ApiController
    {
        private Database1Entities db = new Database1Entities();

        // GET: api/Panels
        public IQueryable<Panel> GetPanels()
        {
            return db.Panels;
        }

        // GET: api/Panels/5
        [ResponseType(typeof(Panel))]
        public IHttpActionResult GetPanel(int id)
        {
            Panel panel = db.Panels.Find(id);
            if (panel == null)
            {
                return NotFound();
            }

            return Ok(panel);
        }

        // PUT: api/Panels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPanel(int id, Panel panel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != panel.Id)
            {
                return BadRequest();
            }

            db.Entry(panel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PanelExists(id))
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

        // POST: api/Panels
        [ResponseType(typeof(Panel))]
        public IHttpActionResult PostPanel(Panel panel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Panels.Add(panel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = panel.Id }, panel);
        }

        // DELETE: api/Panels/5
        [ResponseType(typeof(Panel))]
        public IHttpActionResult DeletePanel(int id)
        {
            Panel panel = db.Panels.Find(id);
            if (panel == null)
            {
                return NotFound();
            }

            db.Panels.Remove(panel);
            db.SaveChanges();

            return Ok(panel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PanelExists(int id)
        {
            return db.Panels.Count(e => e.Id == id) > 0;
        }
    }
}
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
    public class TeacherVerfsController : ApiController
    {
        private Database1Entities db = new Database1Entities();

        // GET: api/TeacherVerfs
        public IQueryable<TeacherVerf> GetTeacherVerfs()
        {
            return db.TeacherVerfs;
        }

        // GET: api/TeacherVerfs/5
        [ResponseType(typeof(TeacherVerf))]
        public IHttpActionResult GetTeacherVerf(int id)
        {
            TeacherVerf teacherVerf = db.TeacherVerfs.Find(id);
            if (teacherVerf == null)
            {
                return NotFound();
            }

            return Ok(teacherVerf);
        }

        // PUT: api/TeacherVerfs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTeacherVerf(int id, TeacherVerf teacherVerf)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teacherVerf.Id)
            {
                return BadRequest();
            }

            db.Entry(teacherVerf).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherVerfExists(id))
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

        // POST: api/TeacherVerfs
        [ResponseType(typeof(TeacherVerf))]
        public IHttpActionResult PostTeacherVerf(TeacherVerf teacherVerf)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TeacherVerfs.Add(teacherVerf);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = teacherVerf.Id }, teacherVerf);
        }

        // DELETE: api/TeacherVerfs/5
        [ResponseType(typeof(TeacherVerf))]
        public IHttpActionResult DeleteTeacherVerf(int id)
        {
            TeacherVerf teacherVerf = db.TeacherVerfs.Find(id);
            if (teacherVerf == null)
            {
                return NotFound();
            }

            db.TeacherVerfs.Remove(teacherVerf);
            db.SaveChanges();

            return Ok(teacherVerf);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeacherVerfExists(int id)
        {
            return db.TeacherVerfs.Count(e => e.Id == id) > 0;
        }
    }
}
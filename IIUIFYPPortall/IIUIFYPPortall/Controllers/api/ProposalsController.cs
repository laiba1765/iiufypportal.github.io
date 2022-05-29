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
    public class ProposalsController : ApiController
    {
        private Database1Entities db = new Database1Entities();

        // GET: api/Proposals
        public IQueryable<Proposal> GetProposals()
        {
            return db.Proposals;
        }

        // GET: api/Proposals/5
        [ResponseType(typeof(Proposal))]
        public IHttpActionResult GetProposal(int id)
        {
            Proposal proposal = db.Proposals.Find(id);
            if (proposal == null)
            {
                return NotFound();
            }

            return Ok(proposal);
        }

        // PUT: api/Proposals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProposal(int id, Proposal proposal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proposal.Id)
            {
                return BadRequest();
            }

            db.Entry(proposal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProposalExists(id))
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

        // POST: api/Proposals
        [ResponseType(typeof(Proposal))]
        public IHttpActionResult PostProposal(Proposal proposal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Proposals.Add(proposal);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = proposal.Id }, proposal);
        }

        // DELETE: api/Proposals/5
        [ResponseType(typeof(Proposal))]
        public IHttpActionResult DeleteProposal(int id)
        {
            Proposal proposal = db.Proposals.Find(id);
            if (proposal == null)
            {
                return NotFound();
            }

            db.Proposals.Remove(proposal);
            db.SaveChanges();

            return Ok(proposal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProposalExists(int id)
        {
            return db.Proposals.Count(e => e.Id == id) > 0;
        }
    }
}
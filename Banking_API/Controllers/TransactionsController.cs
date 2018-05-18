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
using Banking_API.Models;

namespace Banking_API.Controllers
{
    [RoutePrefix("api/Transaction")]
    public class TransactionsController : ApiController
    {
        private DataContext db = new DataContext();

        /*
        // PUT: api/Transactions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccount(int id, Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != account.Id)
            {
                return BadRequest();
            }

            db.Entry(account).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }*/

        // POST: api/Transactions
        [Route("{origin:int}/{recipient:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PostAccount(int origin, int recipient, [FromBody]decimal amount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Accounts.Find(origin).Balance -= amount;
            db.Accounts.Find(recipient).Balance += amount;

            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccountExists(int id)
        {
            return db.Accounts.Count(e => e.Id == id) > 0;
        }
    }
}
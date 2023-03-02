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
using WEB_API;

namespace WEB_API.Controllers
{
    public class tbl_Employee_MasterController : ApiController
    {
        private DB_EmployeeEntities db = new DB_EmployeeEntities();

        // GET: api/tbl_Employee_Master
        public IQueryable<tbl_Employee_Master> Gettbl_Employee_Master()
        {
            return db.tbl_Employee_Master;
        }

        // GET: api/tbl_Employee_Master/5
        [ResponseType(typeof(tbl_Employee_Master))]
        public IHttpActionResult Gettbl_Employee_Master(int id)
        {
            tbl_Employee_Master tbl_Employee_Master = db.tbl_Employee_Master.Find(id);
            if (tbl_Employee_Master == null)
            {
                return NotFound();
            }

            return Ok(tbl_Employee_Master);
        }

        // PUT: api/tbl_Employee_Master/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_Employee_Master(int id, tbl_Employee_Master tbl_Employee_Master)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Employee_Master.Employee_Id)
            {
                return BadRequest();
            }

            db.Entry(tbl_Employee_Master).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_Employee_MasterExists(id))
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

        // POST: api/tbl_Employee_Master
        [ResponseType(typeof(tbl_Employee_Master))]
        public IHttpActionResult Posttbl_Employee_Master(tbl_Employee_Master tbl_Employee_Master)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Employee_Master.Add(tbl_Employee_Master);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Employee_Master.Employee_Id }, tbl_Employee_Master);
        }

        // DELETE: api/tbl_Employee_Master/5
        [ResponseType(typeof(tbl_Employee_Master))]
        public IHttpActionResult Deletetbl_Employee_Master(int id)
        {
            tbl_Employee_Master tbl_Employee_Master = db.tbl_Employee_Master.Find(id);
            if (tbl_Employee_Master == null)
            {
                return NotFound();
            }

            db.tbl_Employee_Master.Remove(tbl_Employee_Master);
            db.SaveChanges();

            return Ok(tbl_Employee_Master);
        }

        [Route("api/tbl_User_Master/getEmployees")]
        [HttpGet]

        public IQueryable<tbl_Employee_Master> getEmployeeList()
        { 
            return db.tbl_Employee_Master; 
        
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_Employee_MasterExists(int id)
        {
            return db.tbl_Employee_Master.Count(e => e.Employee_Id == id) > 0;
        }
    }
}
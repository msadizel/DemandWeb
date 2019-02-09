using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemandWebService.Controllers
{
    public class ValuesController : ApiController
    {
        DemandContext db = new DemandContext();

        // GET api/values
        public IEnumerable<DemandHeader> GetDemandHeaders()
        {
            return db.DemandHeader.Where(x=>x.DphNum.Contains("19."));
        }
        public DemandHeader Get(int id)
        {
            DemandHeader demandHeader = db.DemandHeader.Find(id);
            return demandHeader;
        }

        // GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}
        [HttpPost]
        public void CreateDemandHeader([FromBody]DemandHeader demandHeader)
        {
            db.DemandHeader.Add(demandHeader);
            db.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut]
        public void EditDemandHeader(int id, [FromBody]DemandHeader demandHeader)
        {
            if (id == demandHeader.DphId)
            {
                db.Entry(demandHeader).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }
        // POST api/values
        //public void Post([FromBody]DemandHeader demandHeader)
        //{
        //    using (DemandContext demandContext = new DemandContext())
        //    {
        //        demandContext.DemandHeader.Add(demandHeader);
        //        demandContext.SaveChanges();
        //    }
        //}

        // PUT api/values/5

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(int id)
        {
            DemandHeader demandHeader = db.DemandHeader.Find(id);
            if (demandHeader!=null)
            {
                db.DemandHeader.Remove(demandHeader);
                db.SaveChanges();
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

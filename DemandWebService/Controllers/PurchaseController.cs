using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemandWebService.Controllers
{
    [RoutePrefix("Purchases")]
    public class PurchasesController : ApiController
    {
        DemandContext db = new DemandContext();
       
        public IEnumerable<DemandPurchase> GetPurchase()
        {
            return db.DemandPurchase.Where(x => x.DpId > 43000);
        }

        [Route("GetMany/{id}")]
        public IEnumerable<DemandPurchase> Get(int id)
        {            
            return db.DemandPurchase.Where(x=>x.DphId==id);
        }

        [Route("GetOne/{id}")]
        public DemandPurchase GetOne(int id)
        {
            DemandPurchase demandPurchase = db.DemandPurchase.Find(id);
            return demandPurchase;
        }
        
        [HttpPost]
        [Route("Create/")]
        public void CreateDemandPurchase([FromBody]DemandPurchase demandPurchase)
        {
            db.DemandPurchase.Add(demandPurchase);
            db.SaveChanges();
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public void EditDemandPurchase(int id, [FromBody]DemandPurchase demandPurchase)
        {
            if (id == demandPurchase.DpId)
            {
                db.Entry(demandPurchase).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            DemandPurchase demandPurchase = db.DemandPurchase.Find(id);
            if (demandPurchase != null)
            {
                db.DemandPurchase.Remove(demandPurchase);
                db.SaveChanges();
            }
        }
    }
}
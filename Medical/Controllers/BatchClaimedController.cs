using Medical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Medical.Controllers
{
    [Route("api/BatchClaimed")]
    public class BatchClaimedController : ApiController
    {

        private MedicalContext db = new MedicalContext(); 

        [ResponseType(typeof(BatchClaimed))]
        [HttpGet]
        public IHttpActionResult GetBatchClaimed()
        {
            List<BatchClaimed> list = db.BatchClaimed.ToList();
            
            if (!list.Any())
            {
                return NotFound();
            }
            return Ok(list);
        }

        [ResponseType(typeof(BatchClaimed))]
        [HttpPost]
        public IHttpActionResult PostBatchClaimed([FromBody] BatchClaimed bc1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.BatchClaimed.Add(bc1);
            db.SaveChanges();

            return Ok("Success");
        }

        [ResponseType(typeof(BatchClaimed))]
        [HttpPut]
        public IHttpActionResult PutBatchClaimed([FromBody] BatchClaimed bc1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var record = db.BatchClaimed.FirstOrDefault(x => (x.date == bc1.date && x.batch_id == bc1.batch_id));
            if (record != null)
            {
                record.collectedEnv = bc1.collectedEnv;
                record.submittedEnv = bc1.submittedEnv;
                record.status = bc1.status;
                db.SaveChanges();
            }

            return Ok("Success");
        }

       
        [ResponseType(typeof(BatchClaimed))]
        public IHttpActionResult DeleteBatchClaimed(BatchClaimed batch)
        //DateTime date , int batch_id
        {
            var record = db.BatchClaimed.FirstOrDefault(x => (x.date == batch.date && x.batch_id == batch.batch_id));
            if (record != null)
            {
                db.BatchClaimed.Remove(record);
                db.SaveChanges();
            }
            return Ok("Successful Deletion");
        }

    }
}

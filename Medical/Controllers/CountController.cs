using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Medical.Models;
using System.Collections;



namespace Medical.Controllers
{
    public class CountController : ApiController
    {
        private MedicalContext db = new MedicalContext();



        public IHttpActionResult GetClaimsCount()
        {



            var query = (from b in db.Batches
                         join c in db.Claims
                         on b.batch_id equals c.batch_id
                         where b.batch_date_to == null
                         select c.number_of_claims).ToList();




            var query1 = (from b in db.Batches
                          join c in db.Claims
                          on b.batch_id equals c.batch_id
                          where b.batch_date_to == null
                          select c.batch_id).FirstOrDefault();



            var detailsList = new ArrayList();

            int sum = query.Sum();
            detailsList.Add(sum);
            detailsList.Add(query1);
            if (query == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(detailsList);
            }
        }
    }
}
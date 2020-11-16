using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Medical.Models
{
    public class BatchClaimed
    {
        [Column(Order = 0), System.ComponentModel.DataAnnotations.Key]
        public DateTime date { get; set; }


        [Column(Order = 1), System.ComponentModel.DataAnnotations.Key, ForeignKey("Batch")]
        public int batch_id { get; set; }
        public int submittedEnv { get; set; }
        public int collecttedEnv { get; set; }
        public string status { get; set; }

        public virtual Batch Batch { get; set; }

    }
}
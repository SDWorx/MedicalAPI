using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical.Models
{
    public class BatchClaimed
    {
        public DateTime date { get; set; }
        public int batch_id { get; set; }
        public int submittedEnv { get; set; }
        public int collecttedEnv { get; set; }
        public string status { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Woffu.PruebaTecnica.WebApplication.Models
{
    public class JobTitle
    {
        public int jobTitleId { get; set; }
        public string name { get; set; }
        public int companyId { get; set; }
    }
}

using DataAccess.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Agents
{
    public class AddSites
    {
        public List<Site> Sites { get; set; }
        
        public int IdEmployee { get; set; }
    }
}

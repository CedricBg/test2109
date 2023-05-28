using BusinessAccessLayer.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Models.Agents
{
    public class AddSites
    {
        public List<Site> Sites { get; set; }

        public int IdEmployee { get; set; }
    }
}

using BusinessAccessLayer.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Models.Discussion
{
    public class Messages
    {
        public int MessageId { get; set; }

        public string Text { get; set; }

        public int SiteId { get; set; }
    }
}

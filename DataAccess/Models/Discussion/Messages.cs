using DataAccess.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Discussion
{
    public class Message
    {
        public int MessageId { get; set; }

        public string Text { get; set; }

        public Site Site { get; set; }  
    }
}

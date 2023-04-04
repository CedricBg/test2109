using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccess.Models.Customer
{
    public class ContactPerson
    {
        public int ContactId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        
        public List<Email> Email { get; set; }
       
        public List<Phone> Phone { get; set; }

        public Boolean? Responsible { get; set; }

        public DateTime Created { get; set; }

        public Boolean? EmergencyContact { get; set; }
        
        public Boolean? NightContact { get; set; }

        public int? SiteId { get; set; }

        public int? ContactSiteId { get; }
        [JsonIgnore]
        public Site ContactSite { get; }

    }
}

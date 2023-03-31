using DataAccess.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Tools
{
    public static class Mapper
    {
        public static List<AllSites> sites(this List<Site> site)
        {
            List<AllSites> allSites = new List<AllSites>();
            foreach (var siteItem in site)
            {
                allSites.Add(new AllSites
                {
                    Name = siteItem.Name,
                    SiteId = siteItem.SiteId
                });
            }
            return allSites;
        }
    }
}

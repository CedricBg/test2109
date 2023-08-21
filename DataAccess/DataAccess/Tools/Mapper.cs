using DataAccess.Models.Customer;



namespace DataAccess.Tools
{
    public static class Mapper
    {
        public static List<AllSites> sites(this List<Site> site)
        {
            List<AllSites> allSites = new List<AllSites>();
            foreach (var siteItem in site)
            {
                if(siteItem.IsDeleted == false)
                {
                    allSites.Add(new AllSites
                    {
                        Name = siteItem.Name,
                        SiteId = siteItem.SiteId,
                    });
                }
            }

            return allSites;
        }
    }
}

using DataAccess.Models;

namespace test2109.Models.Customer
{
    /// <summary>
    /// Class qui permet de crée un site sur base d'un id client
    /// également pour le retour des donnèes apres création pour mise a jour des donnèes dans angular
    /// </summary>
    public class Site
    {
        public int? SiteId { get; set; }

        public string Name { get; set; }

        public string? VatNumber { get; set; }

        public bool? IsDeleted { get; set; }

        public List<ContactPerson>? ContactSite { get; set; }

        public DateTime? CreationDate { get; set; }

        public Language? Language { get; set; }

        public Address Address { get; set; }

        public int? CustomerIdCreate { get; set; }
    }
}

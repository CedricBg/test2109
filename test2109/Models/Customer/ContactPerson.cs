using test2109.Models.Employee;

namespace test2109.Models.Customer
{
 /// <summary>
/// Class qui renvoi les personnes de contact pour site et (customer->(pas encore en place))
/// </summary>
    public class ContactPerson
    {
        public int ContactId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        
        public List<Email> Email { get; set; }
        
        public List<Phone> Phone { get; set; }

        /// <summary>
        /// Pour savoir si responsable d'un site
        /// </summary>
        public Boolean? Responsible { get; set; }

        /// <summary>
        /// Pour savoir si contact d'urgance d'un site
        /// </summary>
        public Boolean? EmergencyContact { get; set; }

        /// <summary>
        /// Pour savoir si contact durant la nuit
        /// </summary>
        public Boolean? NightContact { get; set; }

        /// <summary>
        /// variable utilisé quand nécessaire pour attribution a une site
        /// </summary>
        public int? SiteId { get; set; }

        /// <summary>
        /// Pour savoir si contact durant la journée
        /// </summary>
        public Boolean? DayContact { get; set; }

    }
}

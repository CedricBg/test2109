using Newtonsoft.Json;

namespace test2109.Models.Employee
{
    /// <summary>
    ///  <para>Classe Email pour lister et creer des emails</para>
    /// </summary>
    public class Email
    {
        [JsonProperty("emailId")]
        public int? EmailId { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }
    }
}

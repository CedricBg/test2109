using Newtonsoft.Json;

namespace test2109.Models.Employee
{
    public class Email
    {
        [JsonProperty("emailId")]
        public int? EmailId { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }
    }
}

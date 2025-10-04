using System.Text.Json.Serialization;

namespace Models.Domain
{
    public class Organization
    {
        public string? Name { get; set; }
        public Guid Guid { get; set; }
        public Guid? UserGuid { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        public Guid? AddressGuid { get; set; }
        [JsonIgnore]
        public Address? Address { get; set; }
    }

}

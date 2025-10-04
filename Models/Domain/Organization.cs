using System.Text.Json.Serialization;

namespace Models.Domain
{
    public class Organization
    {
        public string? Name { get; set; }
        public Guid Guid { get; set; }
        public required Guid UserGuid { get; set; }
        [JsonIgnore]
        public required User User { get; set; }
        public required Guid AddressGuid { get; set; }
        [JsonIgnore]
        public required Address Address { get; set; }
    }

}

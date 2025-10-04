using System.Text.Json.Serialization;

namespace Models.Domain
{
    public class School
    {
        public Guid Guid { get; set; }
        public required Guid UserGuid { get; set; }
        [JsonIgnore]
        public Address Address { get; set; }
        public Guid AddressGuid { get; set; }
        public string? Name { get; set; }
        [JsonIgnore]
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}


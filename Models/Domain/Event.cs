using System.Text.Json.Serialization;

namespace Models.Domain
{
    public class Event
    {
        public Guid Guid { get; set; }
        public Guid? OrganizationGuid { get; set; }
        [JsonIgnore]
        public Organization? Organization{ get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid? AddressGuid { get; set; }
        [JsonIgnore]
        public Address? Address { get; set; }
        public string? Qualifications { get; set; }
        public bool Closed { get; set; } = false;
        [JsonIgnore]
        public ICollection<UserEvent> UserEvents { get; set; } = new List<UserEvent>();
    }
}

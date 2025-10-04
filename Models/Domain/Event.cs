namespace Models.Domain
{
    public class Event
    {
        public Guid Guid { get; set; }
        public Guid OrganizationGuid { get; set; }
        public Organization Organization{ get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public required Guid AddressGuid { get; set; }
        public required Address Address { get; set; }
        public string? Qualifications { get; set; }
        public bool Closed { get; set; } = false;
        public ICollection<UserEvent> UserEvents { get; set; } = new List<UserEvent>();
    }
}

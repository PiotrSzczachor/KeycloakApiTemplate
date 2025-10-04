namespace Models.Domain
{
    public class Organization
    {
        public string? Name { get; set; }
        public Guid Guid { get; set; }
        public required Guid UserGuid { get; set; }
        public required User User { get; set; }
        public required Guid AddressGuid { get; set; }
        public required Address Address { get; set; }
    }

}

namespace Models.Domain
{
    public class Address
    {
        public Guid? Guid { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public required string PostalCode { get; set; }
    }
}

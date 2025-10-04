namespace Models.Domain
{
    public class School
    {
        public Guid Guid { get; set; }

        public Address Address { get; set; }
        public Guid AddressGuid { get; set; }
        public string? Name { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}


namespace Models.Domain
{
    public sealed class User
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string? Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Role { get; set; }
        public Guid? SchoolGuid { get; set; }
        public School School { get; set; }
        public Guid? OrganizationGuid { get; set; }
        public Organization Organization { get; set; }
        public ICollection<UserEvent> UserEvents { get; set; } = new List<UserEvent>();

    }
}

namespace Models.Domain
{
    public class UserEvent
    {
        public Guid UserGuid {  get; set; }
        public User User { get; set; }
        public Guid EventGuid { get; set; }
        public Event Event { get; set; }
    }
}

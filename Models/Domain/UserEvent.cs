using System.Text.Json.Serialization;

namespace Models.Domain
{
    public class UserEvent
    {
        public Guid? UserGuid {  get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        public Guid? EventGuid { get; set; }
        [JsonIgnore]
        public Event? Event { get; set; }
    }
}

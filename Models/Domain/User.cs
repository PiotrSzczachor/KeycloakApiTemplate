using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Domain
{
    public sealed class User
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}

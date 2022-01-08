using System;
using System.Collections.Generic;
using System.Text;

namespace Avo.SoftDev.Domain.Persons
{
    public class User
    {
        public string Name { get; }
        public UserRole UserRole { get; }
        public User(string Name,UserRole UserRole)
        {
            this.Name = Name;
            this.UserRole = UserRole;
        }
    }
}

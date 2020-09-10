using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Tests
{
    public class PlayerCharacter
    {
        public int Health = 100;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string NickName { get; set; }
        public bool IsNoob { get; set; }
            
    }
}

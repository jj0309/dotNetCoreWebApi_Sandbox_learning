using System.Collections.Generic;

namespace _dotnetSandBox.Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<Character> characters { get; set; }
    }
}
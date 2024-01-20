using SocialNetwork.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Entities.Concreate
{
    public class AppUser : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string EmailToken { get; set; }
        public bool EmailConfirm { get; set; }
        public DateTime EmailExpiresData { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}

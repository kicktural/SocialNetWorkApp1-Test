using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNotework.Entities.DTOs.UserDTOs
{
    public class UserProfileDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Avatar { get; set; }
        public string CoverPhoto { get; set; }
    }
}

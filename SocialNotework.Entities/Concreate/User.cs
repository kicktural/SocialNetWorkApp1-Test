using SocialNetwork.Core.Entities.Abstract;
using SocialNetwork.Core.Entities.Concreate;
using SocialNotework.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNotework.Entities.Concreate
{
    public class User : AppUser, IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Avatar { get; set; }
        public string CoverPhoto { get; set; }
        public Gender Gender { get; set; }
        public List<FriendList> FriendLists { get; set; }
    }
}

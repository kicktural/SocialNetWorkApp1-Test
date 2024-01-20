using SocialNetwork.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNotework.Entities.Concreate
{
    public class FriendList : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int FriendId { get; set; }
        public User Friend { get; set; }
    }
}

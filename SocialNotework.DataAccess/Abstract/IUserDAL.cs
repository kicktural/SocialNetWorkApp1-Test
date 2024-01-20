using SocialNetwork.Core.DataAccess;
using SocialNotework.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNotework.DataAccess.Abstract
{
    public interface IUserDAL : IRepositoryBase<User>
    {
    }
}

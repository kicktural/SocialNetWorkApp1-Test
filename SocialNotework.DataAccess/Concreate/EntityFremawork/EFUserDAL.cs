using SocialNetwork.Core.DataAccess.EntityFremawork;
using SocialNotework.DataAccess.Abstract;
using SocialNotework.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNotework.DataAccess.Concreate.EntityFremawork
{
    public class EFUserDAL : EFRepositoryBase<User, AppDBcontext>, IUserDAL
    {
    }
}

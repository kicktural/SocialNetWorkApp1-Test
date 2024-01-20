using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Utilities.EmailHelper
{
    public interface IMailHelper
    {
        bool SendMail(string mailAddress, string token, bool bodyHtml);
    }
}

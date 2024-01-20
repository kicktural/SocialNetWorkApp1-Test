using SocialNetwork.Core.Utilities.Result.Abstract;
using SocialNetwork.Core.Utilities.Result.Concreate.ErrorResult;
using SocialNetwork.Core.Utilities.Result.Concreate.SuccessResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Utilities.Business
{
    public static class BusinessRules
    {
        public static IResult Check(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                    return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}

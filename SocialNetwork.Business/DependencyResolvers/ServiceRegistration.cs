using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Business.Abstract;
using SocialNetwork.Business.AutoMapper;
using SocialNetwork.Business.Concreate;
using SocialNetwork.Core.Utilities.EmailHelper;
using SocialNotework.DataAccess.Abstract;
using SocialNotework.DataAccess.Concreate.EntityFremawork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Business.DependencyResolvers
{
    public static class ServiceRegistration
    {
        public static void Create(this IServiceCollection services)
        {
            services.AddScoped<AppDBcontext>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserDAL, EFUserDAL>();
            services.AddTransient<IMailHelper, MailHelper>();

            var MapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<MappingProfile>();
            });

            IMapper mapper = MapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}

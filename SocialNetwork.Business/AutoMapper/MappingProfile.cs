using AutoMapper;
using SocialNotework.Entities.Concreate;
using SocialNotework.Entities.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Business.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterDTO, User>().ReverseMap();
        } 
    }
}

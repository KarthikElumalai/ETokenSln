using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EToken.Core.Model;
using EToken.Infrustructure;
using EToken.Infrustructure.Resource;

namespace EToken.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserResource>();
            CreateMap<UserResource, User>();
        }
    }
}

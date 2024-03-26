using Application.Models;
using AutoMapper;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserModel>()
                .ForMember(dst => dst.hoTen, opt => opt.MapFrom(x => x.hoTen))
                .ForMember(dst => dst.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(dst => dst.phone, opt => opt.MapFrom(x => x.PhoneNumber))
                .ForMember(dst => dst.UserName, opt => opt.MapFrom(x => x.UserName));
            CreateMap<UserModel, ApplicationUser>();
        }
    }
}

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
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Loaisp, CategoryModel>()
                .ForMember(dst => dst.LoaiId, otp => otp.MapFrom(o => o.LoaiId))
                .ForMember(dst => dst.LoaiName, otp => otp.MapFrom(o => o.LoaiName));
            CreateMap<CategoryModel, Loaisp>();
        }
    }
}

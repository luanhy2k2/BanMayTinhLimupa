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
    public class ProductStonkProfile:Profile
    {
        public ProductStonkProfile()
        {
            CreateMap<ChiTietKho, ProductStonkModel>()
                .ForMember(dst => dst.SanpId, otp => otp.MapFrom(x => x.SanpId))
                .ForMember(dst => dst.SanpName, otp => otp.MapFrom(x => x.Sanp.SanpName))
                .ForMember(dst => dst.Quantity, otp => otp.MapFrom(x => x.SoLuong))
                .ForMember(dst => dst.Image, otp => otp.MapFrom(x => x.Sanp.Image));
            CreateMap<ProductStonkModel, ChiTietKho>();
        }
    }

}

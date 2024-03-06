using Application.Models;
using AutoMapper;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Sanpham, ProductModel>()
                .ForMember(dst => dst.SanpId, otp => otp.MapFrom(o => o.SanpId))
                .ForMember(dst => dst.SanpName, otp => otp.MapFrom(o => o.SanpName))
                .ForMember(dst => dst.Ram, otp => otp.MapFrom(o => o.Ram))
                .ForMember(dst => dst.Rom, otp => otp.MapFrom(o => o.Rom))
                .ForMember(dst => dst.Cpu, otp => otp.MapFrom(o => o.Cpu))
              
                .ForMember(dst => dst.Image, otp => otp.MapFrom(o => o.Image))
                .ForMember(dst => dst.Price, otp => otp.MapFrom(o =>o.GiaCas.Select(x => x.Gia).First()))
                .ForMember(dst => dst.Battery, otp => otp.MapFrom(o => o.Battery))
                .ForMember(dst => dst.Card, otp => otp.MapFrom(o => o.Card))
                .ForMember(dst => dst.Display, otp => otp.MapFrom(o => o.Display))
                .ForMember(dst => dst.Namsx, otp => otp.MapFrom(o => o.Namsx))
               
                .ForMember(dst => dst.LoaiName, otp => otp.MapFrom(o => o.Loai.LoaiName))
              
                .ForMember(dst => dst.NsxName, otp => otp.MapFrom(o => o.Nsx.NsxName));
            CreateMap<ProductModel, Sanpham>();
        }
    }
}

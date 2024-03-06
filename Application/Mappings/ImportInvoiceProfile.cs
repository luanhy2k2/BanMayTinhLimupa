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
    public class ImportInvoiceProfile:Profile
    {
        public ImportInvoiceProfile()
        {
            CreateMap<HoaDonNhap, ImportInvoiceModel>()
                .ForMember(dst => dst.SoHoaDon, otp => otp.MapFrom(o => o.SoHoaDon))
                .ForMember(dst => dst.ToTal, otp => otp.MapFrom(o => o.ToTal))
                .ForMember(dst => dst.NgayNhap, otp => otp.MapFrom(o => o.NgayNhap))
                .ForMember(dst => dst.HoTen, otp => otp.MapFrom(o => o.MaNguoiDungNavigation.hoTen));
            CreateMap<ImportInvoiceModel, HoaDonNhap>();
        }
    }
}

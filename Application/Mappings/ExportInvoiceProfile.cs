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
    public class ExportInvoiceProfile:Profile
    {
        public ExportInvoiceProfile()
        {
            CreateMap<HoaDonBan, ExportInvoiceModel>()
                .ForMember(dst => dst.SoHoaDon, otp => otp.MapFrom(x => x.SoHoaDon))
                .ForMember(dst => dst.NgayBan, otp => otp.MapFrom(x => x.NgayBan))
                .ForMember(dst => dst.ToTal, otp => otp.MapFrom(x => x.ToTal))
                .ForMember(dst => dst.MaKhachHang, otp => otp.MapFrom(x => x.MaKhachHang))
                .ForMember(dst => dst.TenKhachHang, otp => otp.MapFrom(x => x.MaKhachHangNavigation.TenKhachHang))
                .ForMember(dst => dst.Email, otp => otp.MapFrom(x => x.MaKhachHangNavigation.Email))
                .ForMember(dst => dst.DiaChi, otp => otp.MapFrom(x => x.MaKhachHangNavigation.DiaChi))
                .ForMember(dst => dst.Phone, otp => otp.MapFrom(x => x.MaKhachHangNavigation.Sdt));
            CreateMap<ExportInvoiceModel, HoaDonBan>();
        }
    }
}

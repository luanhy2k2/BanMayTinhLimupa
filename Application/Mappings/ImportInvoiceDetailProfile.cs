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
    public class ImportInvoiceDetailProfile:Profile
    {
        public ImportInvoiceDetailProfile()
        {
            CreateMap<ChiTietHoaDonNhap, ImportInvoiceDetailModel>()
                .ForMember(dst => dst.SanpId, otp => otp.MapFrom(o => o.SanpId))
                .ForMember(dst => dst.SanpName, otp => otp.MapFrom(o => o.Sanp.SanpName))
                .ForMember(dst => dst.SoHoaDon, otp => otp.MapFrom(o => o.SoHoaDon))
                .ForMember(dst => dst.MaChiTietHoaDonNhap, otp => otp.MapFrom(o => o.MaChiTietHoaDonNhap))
                .ForMember(dst => dst.Image, otp => otp.MapFrom(o => o.Sanp.Image))
                .ForMember(dst => dst.SoLuong, otp => otp.MapFrom(o => o.SoLuong))
                .ForMember(dst => dst.DonGia, otp => otp.MapFrom(o => o.DonGia));
            CreateMap<ImportInvoiceDetailModel, ChiTietHoaDonNhap>();
        }
    }
}

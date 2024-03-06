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
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<DonHang, OrderModel>()
                .ForMember(dst => dst.MaDonHang, otp => otp.MapFrom(o => o.MaDonHang))
                .ForMember(dst => dst.NgayDat, otp => otp.MapFrom(o => o.NgayDat))
                .ForMember(dst => dst.TrangThai, otp => otp.MapFrom(o => o.TrangThai))
                .ForMember(dst => dst.TrangThaiGiaoHang, otp => otp.MapFrom(o => o.TrangThaiGiaoHang))
                .ForMember(dst => dst.TrangThaiThanhToan, otp => otp.MapFrom(o => o.TrangThaiThanhToan))
                .ForMember(dst => dst.ToTal, otp => otp.MapFrom(o => o.ToTal))
                .ForMember(dst => dst.MaKhachHang, otp => otp.MapFrom(o => o.MaKhachHang))
                .ForMember(dst => dst.TenKhachHang, otp => otp.MapFrom(o => o.MaKhachHangNavigation.TenKhachHang))
                .ForMember(dst => dst.DiaChi, otp => otp.MapFrom(o => o.MaKhachHangNavigation.DiaChi))
                .ForMember(dst => dst.Email, otp => otp.MapFrom(o => o.MaKhachHangNavigation.Email))
                
                .ForMember(dst => dst.Sdt, otp => otp.MapFrom(o => o.MaKhachHangNavigation.Sdt));
                
            CreateMap<OrderModel, DonHang>();
        }
    }
}

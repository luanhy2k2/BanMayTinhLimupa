using Application.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.Admin
{
    public interface IImportInvoiceRepository
    {
        Task<HoaDonNhap> createInvoice(HoaDonNhap entity);
        Task<ChiTietHoaDonNhap> createInvoiceDetail(ChiTietHoaDonNhap detail);
        Task<BaseQueryReponseModel<HoaDonNhap>> getAllInvoice(int pageIndex, int pageSize);
        Task<List<ChiTietHoaDonNhap>> getInvoiceDetailById(int id);
        Task<HoaDonNhap> getInvoiceById(int id);
    }
}

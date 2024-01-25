using Model.Models;
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
        Task<Object> getAllInvoice(int pageIndex, int pageSize);
        Task<Object> getInvoiceDetailById(int id);
        Task<Object> getInvoiceById(int id);
    }
}

using Application.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface.Admin
{
    public interface IImportInvoiceService
    {
        Task<HoaDonNhap> createInvoice(HoaDonNhap entity);
        Task<ChiTietHoaDonNhap> createInvoiceDetail(ChiTietHoaDonNhap detail);
        Task<BaseQueryReponseModel<ImportInvoiceModel>> getAllInvoice(int pageIndex, int pageSize);
        Task<List<ImportInvoiceDetailModel>> getInvoiceDetailById(int id);
        Task<ImportInvoiceModel> getInvoiceById(int id);
    }
}

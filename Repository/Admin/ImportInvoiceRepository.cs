using Application.Models;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interface.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Admin
{
    public class ImportInvoiceRepository : IImportInvoiceRepository
    {
        private QuanlybanhangContext _dbContext;
        public ImportInvoiceRepository(QuanlybanhangContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<HoaDonNhap> createInvoice(HoaDonNhap entity)
        {
            try
            {
                var query = await _dbContext.HoaDonNhap.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex)
            {
                throw new Exception("Error while manipulating the database", ex);
            }
        }

        public async Task<ChiTietHoaDonNhap> createInvoiceDetail(ChiTietHoaDonNhap detail)
        {
            try
            {
                // Retrieve the price for the product
                var price = await _dbContext.GiaCa
                    .FirstOrDefaultAsync(x => x.SanpId == detail.SanpId);

                // Calculate the total price for the invoice detail
                var totalOfInvoiceDetail = price?.Gia * detail.SoLuong ?? 0;
                detail.DonGia = totalOfInvoiceDetail;

                // Add the invoice detail to the database
                var addedDetail = await _dbContext.ChiTietHoaDonNhap.AddAsync(detail);

                // Update product quantity in the warehouse
                var productQuantity = await _dbContext.ChiTietKho
                    .FirstOrDefaultAsync(x => x.SanpId == detail.SanpId);

                if (productQuantity != null)
                {
                    productQuantity.SoLuong += detail.SoLuong;
                }
                else
                {
                   
                    throw new InvalidOperationException("Product quantity not found for the specified product.");
                }

                var invoice = await _dbContext.HoaDonNhap
                    .FirstOrDefaultAsync(x => x.SoHoaDon == detail.SoHoaDon);

                if (invoice != null)
                {
                    invoice.ToTal += totalOfInvoiceDetail;
                }
                else
                {
                   
                    throw new InvalidOperationException("Purchase invoice not found for the specified invoice number.");
                }

                await _dbContext.SaveChangesAsync();

                return addedDetail.Entity;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error while manipulating the database: {ex.Message}");
                throw;
            }
        }

        

        public async Task<BaseQueryReponseModel<HoaDonNhap>> getAllInvoice(int pageIndex, int pageSize)
        {
            try
            {
                var query = _dbContext.HoaDonNhap.Include(x => x.MaNguoiDungNavigation);
                var result = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
                var totalCount = await query.CountAsync();
                return new BaseQueryReponseModel<HoaDonNhap>{ Items = result, PageIndex = pageIndex, PageSize = pageSize, Total = totalCount };
            }
            catch (Exception ex)
            {
                throw new Exception("Error while manipulating the database", ex);
            }
        }

        public async Task<HoaDonNhap> getInvoiceById(int id)
        {
            try
            {
                //var query = from invoice in _dbContext.HoaDonNhap

                //            select new
                //            {
                //                invoice.SoHoaDon,
                //                invoice.ToTal,
                //                invoice.NgayNhap,
                //                invoice.MaNguoiDungNavigation.hoTen
                //            };
                var query = _dbContext.HoaDonNhap.Include(x => x.MaNguoiDungNavigation);
                var result = await query.FirstOrDefaultAsync(x =>x.SoHoaDon == id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while manipulating the database", ex);
            }
        }

        public async Task<List<ChiTietHoaDonNhap>> getInvoiceDetailById(int id)
        {
            try
            {
                //var query = from invoiceDetail in _dbContext.ChiTietHoaDonNhap join product in _dbContext.Sanpham
                //            on invoiceDetail.SanpId equals product.SanpId
                //            select new
                //            {
                //                invoiceDetail.DonGia, invoiceDetail.Nsx.NsxName, invoiceDetail.MaChiTietHoaDonNhap, invoiceDetail.SoHoaDon, invoiceDetail.SoLuong, product.SanpId,
                //                product.SanpName, product.Image
                //            };
                var query = _dbContext.ChiTietHoaDonNhap.Include(x => x.Sanp).Include(nsx =>nsx.Nsx);
                var result = await query.Where(x => x.SoHoaDon == id).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while manipulating the database", ex);
            }
        }
    }
}

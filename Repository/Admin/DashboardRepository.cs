using Data;
using Microsoft.EntityFrameworkCore;
using Repository.Interface.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Admin
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly QuanlybanhangContext _context;
        public DashboardRepository(QuanlybanhangContext context)
        {
            _context = context;
        }

        public async Task<int> OrderDuringDay()
        {
            try
            {
                var result = await _context.DonHang.Where(o => o.NgayDat == DateTime.Today).CountAsync();
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("Error in repository", ex);
            }
        }

        public async Task<int> OrderDuringMonth()
        {
            try
            {
                DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);
                var result = await _context.DonHang.Where(o => o.NgayDat >= startDate && o.NgayDat <= endDate).CountAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in repository", ex);
            }
        }

        public async Task<int> RevenueDuringDay()
        {
            try
            {
                var result = await _context.HoaDonBan
                    .Where(o => o.NgayBan == DateTime.Today).SumAsync(x =>(int)x.ToTal);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in repository", ex);
            }
        }

        public async Task<int> RevenueDuringMonth()
        {
            try
            {
                DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);
                var result = await _context.HoaDonBan
                    .Where(o => o.NgayBan >= startDate && o.NgayBan <= endDate).SumAsync(x => (int)x.ToTal);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in repository", ex);
            }
        }

        public async Task<int> TotalProduct()
        {
            try
            {
                var result = await _context.Sanpham.CountAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in repository", ex);
            }
        }

        public async Task<int> TotalUser()
        {
            try
            {
                var result = await _context.Users.CountAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in repository", ex);
            }
        }
    }
}

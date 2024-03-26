using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface.Admin
{
    public interface IDashboardService
    {
        public Task<int> OrderDuringDay();
        public Task<int> OrderDuringMonth();
        public Task<int> RevenueDuringDay();
        public Task<int> RevenueDuringMonth();
        public Task<int> TotalProduct();
        public Task<int> TotalUser();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.entity
{
    public class UserWithRoleViewModel
    {
        public string UserId { get; set; }
        public string hoTen { get;set; }
        public string phone { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
}

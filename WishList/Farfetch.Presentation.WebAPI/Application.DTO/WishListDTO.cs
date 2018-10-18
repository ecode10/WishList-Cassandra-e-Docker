using System;
using System.Collections.Generic;
using System.Text;

namespace Farfetch.Application.DTO
{
    /// <summary>
    /// DTO Wish List
    /// 
    /// </summary>
    public class WishListDTO
    {
        public Guid Id { get; set; }

        public int User_Id { get; set; }

        public int Tenant_Id { get; set; }

        public DateTimeOffset Created_At { get; set; }
    }
}

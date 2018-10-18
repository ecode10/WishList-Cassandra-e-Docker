using System;
using System.Collections.Generic;
using System.Text;

namespace Farfetch.Domain.Service
{
    /// <summary>
    /// Data Domain WishList
    /// </summary>
    public class WishListDomainService
    {
        public Guid Id { get; set; }

        public int User_Id { get; set; }

        public int Tenant_Id { get; set; }

        public DateTime Created_At { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Farfetch.Domain.Model
{
    /// <summary>
    /// Data Domain WishList
    /// </summary>
    public class WishListModel
    {
        public Guid Id { get; set; }

        public int User_Id { get; set; }

        public int Tenant_Id { get; set; }

        public DateTimeOffset Created_At { get; set; }
    }
}

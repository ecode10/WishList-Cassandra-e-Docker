using System;
using System.Collections.Generic;
using System.Text;

namespace Farfetch.Domain.Service
{
    /// <summary>
    /// Data Domain WishList Item
    /// </summary>
    public class WishListItemDomainService
    {
        public Guid Id { get; set; }

        public int Product_Id { get; set; }

        public int Quantity { get; set; }

        public String Product_Name { get; set; }

        public DateTime Created_At { get; set; }

        public DateTime Updated_At { get; set; }
    }
}

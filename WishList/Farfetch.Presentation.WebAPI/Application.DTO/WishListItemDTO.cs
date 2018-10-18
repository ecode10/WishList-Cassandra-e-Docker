using System;
using System.Collections.Generic;
using System.Text;

namespace Farfetch.Application.DTO
{
    /// <summary>
    /// Classe DTO 
    /// Wish List Item
    /// </summary>
    public class WishListItemDTO
    {
        public Guid Id { get; set; }

        public Guid Product_Id { get; set; }

        public int Quantity { get; set; }

        public String Product_Name { get; set; }

        public DateTimeOffset Created_At { get; set; }

        public DateTimeOffset Updated_At { get; set; }

    }
}

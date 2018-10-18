using Farfetch.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farfetch.Data.Repository.Interface
{
    public interface IWishListItemData
    {
        /// <summary>
        /// Method to create list to return
        /// </summary>
        /// <param name="result"></param>
        /// <param name="listItemWish"></param>
        Boolean CreateWhishListItem(WishListItemModel itemService);

        /// <summary>
        /// Method that get all wish list item
        /// </summary>
        /// <returns>List</returns>
        List<WishListItemModel> GetAllWhishListItem();

        /// <summary>
        /// Method that get wish list by name
        /// </summary>
        /// <returns>List</returns>
        List<WishListItemModel> GetWhishListItemByName(WishListItemModel itemService);

        /// <summary>
        /// Get Wish List By Id
        /// SELECT
        /// </summary>
        /// <param name="itemService">WishListItemService</param>
        /// <returns>RowSet</returns>
        List<WishListItemModel> GetWhishListItemById(WishListItemModel itemService);

        /// <summary>
        /// Update Whish List Item
        /// </summary>
        /// <param name="itemService">WishListItemService</param>
        /// <returns>Boolean</returns>
        Boolean UpdateWhishListItem(WishListItemModel itemService);

        /// <summary>
        /// Update Whish List Item
        /// </summary>
        /// <param name="itemService">WishListItemService</param>
        /// <returns>Boolean</returns>
        Boolean DeleteWhishListItem(WishListItemModel itemService);
    }
}

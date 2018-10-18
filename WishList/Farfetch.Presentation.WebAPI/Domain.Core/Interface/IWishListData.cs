using Farfetch.Domain.Model;
using System;
using System.Collections.Generic;

namespace Farfetch.Domain.Core.Interface
{
    /// <summary>
    /// Interface to access Data
    /// </summary>
    public interface IWishListData
    {

        /// <summary>
        /// Create list
        /// </summary>
        /// <param name="itemService"></param>
        /// <returns></returns>
        Boolean CreateWhishList(WishListModel itemService);

        /// <summary>
        /// Get list by Id
        /// </summary>
        /// <param name="itemService"></param>
        /// <returns></returns>
        List<WishListModel> GetWhishListById(WishListModel itemService);

        /// <summary>
        /// Update List
        /// </summary>
        /// <param name="itemService"></param>
        /// <returns></returns>
        Boolean UpdateWhishList(WishListModel itemService);

        /// <summary>
        /// Get all wish list
        /// </summary>
        /// <returns></returns>
        List<WishListModel> GetAllWhishList();

        /// <summary>
        /// Method of delete wish list
        /// </summary>
        /// <param name="itemService">WishListModel</param>
        /// <returns>Boolean</returns>
        Boolean DeleteWhishList(WishListModel itemService);
    }
}

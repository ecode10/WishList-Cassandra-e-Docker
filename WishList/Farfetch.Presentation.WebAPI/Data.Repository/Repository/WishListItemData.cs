using Cassandra;
using Farfetch.Data.Repository.Interface;
using Farfetch.Domain.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farfetch.Data.Repository
{
    /// <summary>
    /// Class Wish List item database entity
    /// </summary>
    public class WishListItemData : CassandraContext, IWishListItemData
    {
        public WishListItemData(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Create the wish list item
        /// </summary>
        /// <param name="itemService">WishListItemDomainService</param>
        /// <returns>Boolean</returns>
        public Boolean CreateWhishListItem(WishListItemModel itemService)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"INSERT INTO WishListItem 
                                            (Id, Product_Id, Quantity, Product_Name, Created_At, Updated_At) 
                                       VALUES (?, ?, ?, ?, ?, ?)");

                var _statement = _sessionCassandra.Prepare(stringBuilder.ToString());

                _sessionCassandra.Execute(_statement.Bind(itemService.Id, itemService.Product_Id,
                                                          itemService.Quantity, itemService.Product_Name,
                                                          itemService.Created_At, itemService.Updated_At));

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method that get all wish list item
        /// </summary>
        /// <returns>List</returns>
        public List<WishListItemModel> GetAllWhishListItem()
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"SELECT Id, Product_Id, Quantity, Product_Name, Created_At, Updated_At 
                                        FROM WishListItem ");

                RowSet result = _sessionCassandra.Execute(stringBuilder.ToString());

                List<WishListItemModel> listItemWish = new List<WishListItemModel>();

                createListFromRowSet(result, listItemWish);

                return listItemWish;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to create list to return
        /// </summary>
        /// <param name="result"></param>
        /// <param name="listItemWish"></param>
        private static void createListFromRowSet(RowSet result, List<WishListItemModel> listItemWish)
        {
            foreach (Row row in result)
            {
                listItemWish.Add(new WishListItemModel
                {
                    Id = (Guid)row["id"],
                    Product_Id = (Guid)row["product_id"],
                    Product_Name = row["product_name"].ToString(),
                    Quantity = Convert.ToInt32(row["quantity"]),
                    Updated_At = row["updated_at"] == null ? DateTimeOffset.MinValue : DateTimeOffset.Parse(row["updated_at"].ToString()),
                    Created_At = DateTimeOffset.Parse(row["created_at"].ToString())
                });
            }
        }

        /// <summary>
        /// Method that get wish list by name
        /// </summary>
        /// <returns>List</returns>
        public List<WishListItemModel> GetWhishListItemByName(WishListItemModel itemService)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"SELECT Id, Product_Id, Quantity, Product_Name, Created_At, Updated_At 
                                        FROM WishListItem
                                       WHERE Product_Name like ? ");

                var _statement = _sessionCassandra.Prepare(stringBuilder.ToString());

                RowSet result = _sessionCassandra.Execute(_statement.Bind("%" + itemService.Product_Name + "%"));

                List<WishListItemModel> listItemWish = new List<WishListItemModel>();

                //create list from RowSet
                createListFromRowSet(result, listItemWish);

                return listItemWish;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Wish List By Id
        /// SELECT
        /// </summary>
        /// <param name="itemService">WishListItemService</param>
        /// <returns>List</returns>
        public List<WishListItemModel> GetWhishListItemById(WishListItemModel itemService)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"SELECT Id, Product_Id, Quantity, Product_Name, Created_At, Updated_At 
                                        FROM WishListItem
                                       WHERE Id = ? ");

                var _statement = _sessionCassandra.Prepare(stringBuilder.ToString());

                RowSet result = _sessionCassandra.Execute(_statement.Bind(itemService.Id));

                List<WishListItemModel> listItemWish = new List<WishListItemModel>();

                //create list from RowSet
                createListFromRowSet(result, listItemWish);

                return listItemWish;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Whish List Item
        /// </summary>
        /// <param name="itemService">WishListItemService</param>
        /// <returns>Boolean</returns>
        public Boolean UpdateWhishListItem(WishListItemModel itemService)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"UPDATE WishListItem SET
                                            Quantity = ?, Product_Name = ?, Updated_At = ?
                                       WHERE Id = ?");

                var _statement = _sessionCassandra.Prepare(stringBuilder.ToString());

                _sessionCassandra.Execute(_statement.Bind(itemService.Quantity, itemService.Product_Name,
                                                          itemService.Updated_At, itemService.Id));

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Whish List Item
        /// </summary>
        /// <param name="itemService">WishListItemService</param>
        /// <returns>Boolean</returns>
        public Boolean DeleteWhishListItem(WishListItemModel itemService)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"DELETE FROM WishListItem 
                                       WHERE Id = ?");

                var _statement = _sessionCassandra.Prepare(stringBuilder.ToString());
                
                _sessionCassandra.Execute(_statement.Bind(itemService.Id));

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

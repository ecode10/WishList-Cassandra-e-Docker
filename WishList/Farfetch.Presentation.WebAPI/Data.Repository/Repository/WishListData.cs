using Cassandra;
using Farfetch.Domain.Core.Interface;
using Farfetch.Domain.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farfetch.Data.Repository
{
    /// <summary>
    /// Class Wish List database entity
    /// </summary>
    public class WishListData : CassandraContext, IWishListData
    {
        public WishListData(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Method that create wish list
        /// Insert
        /// </summary>
        /// <param name="itemService">WishListService</param>
        /// <returns>Boolean</returns>
        public Boolean CreateWhishList(WishListModel itemService)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"INSERT INTO WishList 
                                            (Id, User_Id, Tenant_Id, Created_At) 
                                       VALUES (?, ?, ?, ?)");

                var _statement = _sessionCassandra.Prepare(stringBuilder.ToString());

                _sessionCassandra.Execute(_statement.Bind(itemService.Id, itemService.User_Id,
                                                          itemService.Tenant_Id, itemService.Created_At));

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method: Get all wish list
        /// SELECT
        /// </summary>
        /// <returns>RowSet</returns>
        public List<WishListModel> GetAllWhishList()
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"SELECT Id, User_Id, Tenant_Id, Created_At
                                        FROM WishList ");

                RowSet result = _sessionCassandra.Execute(stringBuilder.ToString());

                List<WishListModel> listWish = new List<WishListModel>();

                //method to create list
                createListToReturn(result, listWish);

                return listWish;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get whish list by Id
        /// SELECT and WHERE
        /// </summary>
        /// <param name="itemService">WishListService</param>
        /// <returns>RowSet</returns>
        public List<WishListModel> GetWhishListById(WishListModel itemService)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"SELECT Id, User_Id, Tenant_Id, Created_At
                                        FROM WishList
                                       WHERE Id = ? ");

                var _statement = _sessionCassandra.Prepare(stringBuilder.ToString());

                RowSet result = _sessionCassandra.Execute(_statement.Bind(itemService.Id));

                List<WishListModel> listWish = new List<WishListModel>();
                
                //method to create list
                createListToReturn(result, listWish);

                return listWish;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method that create list to return inside the methods
        /// </summary>
        /// <param name="result">RowSet</param>
        /// <param name="listWish">WishListModel</param>
        private static void createListToReturn(RowSet result, List<WishListModel> listWish)
        {
            foreach (Row row in result)
            {
                listWish.Add(new WishListModel
                {
                    Id = (Guid)row["id"],
                    User_Id = Convert.ToInt32(row["user_id"]),
                    Tenant_Id = Convert.ToInt32(row["tenant_id"]),
                    Created_At = DateTimeOffset.Parse(row["created_at"].ToString())
                });
            }
        }

        /// <summary>
        /// Method: Update wish list by Id
        /// Update
        /// </summary>
        /// <param name="itemService">WishListService</param>
        /// <returns>Boolean</returns>
        public Boolean UpdateWhishList(WishListModel itemService)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"UPDATE WishList SET
                                            User_Id = ?, Tenant_Id = ?, Created_At = ?
                                       WHERE Id = ?");

                var _statement = _sessionCassandra.Prepare(stringBuilder.ToString());

                _sessionCassandra.Execute(_statement.Bind(itemService.User_Id, itemService.Tenant_Id,
                                                          itemService.Created_At, itemService.Id));

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method of delete wish list
        /// </summary>
        /// <param name="itemService">WishListModel</param>
        /// <returns>Boolean</returns>
        public Boolean DeleteWhishList(WishListModel itemService)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"DELETE FROM WishList
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

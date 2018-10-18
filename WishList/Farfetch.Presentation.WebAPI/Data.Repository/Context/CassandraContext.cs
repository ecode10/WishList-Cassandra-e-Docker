using System;
using System.Collections.Generic;
using System.Text;
using Cassandra;
using Microsoft.Extensions.Configuration;

namespace Farfetch.Data.Repository
{
    /// <summary>
    /// Class Context of Cassandra
    /// </summary>
    public class CassandraContext
    {
        ///// <summary>
        ///// Configuration: Get the file appsettings
        ///// </summary>
        protected IConfiguration _configuration { get; set; }

        /// <summary>
        /// Cluster Cassandra
        /// </summary>
        protected Cluster _cluster;

        /// <summary>
        /// Session Cassandra
        /// </summary>
        protected ISession _sessionCassandra;

        /// <summary>
        /// Constructor
        /// Configurate the cluster
        /// </summary>
        public CassandraContext(IConfiguration configuration)
        {
            if (_cluster == null)
                _cluster = Cluster.Builder()
                    .AddContactPoint(configuration["ClusterCassandra:IP"])
                    .WithQueryTimeout(1000)
                    //.WithCredentials("joao", "password1")
                    .Build();

            if (_sessionCassandra == null)
                _sessionCassandra = _cluster.Connect(configuration["ClusterCassandra:ClusterName"]);

            //create tables if not exist
            CreateTableIfNotExist();

        }

        /// <summary>
        /// Create tables if not exists
        /// MauricioJuniorWishListItem
        /// MauricioJuniorWishList
        /// </summary>
        private void CreateTableIfNotExist()
        {
            //MauricioJuniorWishList
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(@"CREATE TABLE IF NOT EXISTS WishList (
                                    Id UUID PRIMARY KEY,
                                    User_Id int,
                                    Tenant_Id int,
                                    Created_AT timestamp);");

            _sessionCassandra.Execute(stringBuilder.ToString());

            //MauricioJuniorWishListItem
            StringBuilder builder = new StringBuilder();
            builder.Append(@"CREATE TABLE IF NOT EXISTS WishListItem (
                              Id UUID PRIMARY KEY,
                              Product_Id UUID,
                              Quantity int,
                              Product_Name varchar,
                              Created_At timestamp,
                              Updated_At timestamp);
                          ");

            _sessionCassandra.Execute(builder.ToString());
        }
    }
}

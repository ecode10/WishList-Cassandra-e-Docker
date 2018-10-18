using Farfetch.Application.DTO;
using Farfetch.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationTest.Helper
{
    public static class ListModelHelper
    {
        public static List<WishListModel> GenerateListModelHelper()
        {
            List<WishListModel> listModel = new List<WishListModel>();
            listModel.Add(new WishListModel
            {
                Id = Guid.Parse("4d861070-c7e5-11e8-be6c-9116fc548b6b"),
                Created_At = DateTimeOffset.Parse("2018-10-04 14:53:49"),
                Tenant_Id = int.Parse("1"),
                User_Id = int.Parse("3")
            });

            listModel.Add(new WishListModel
            {
                Id = Guid.Parse("4aabc750-c7e5-11e8-be6c-9116fc548b6b"),
                Created_At = DateTimeOffset.Parse("2018-10-04 14:53:44"),
                Tenant_Id = int.Parse("1"),
                User_Id = int.Parse("2")
            });

            listModel.Add(new WishListModel
            {
                Id = Guid.Parse("51f24430-c7e5-11e8-be6c-9116fc548b6b"),
                Created_At = DateTimeOffset.Parse("2018-10-04 00:00:00"),
                Tenant_Id = int.Parse("1"),
                User_Id = int.Parse("4")
            });

            listModel.Add(new WishListModel
            {
                Id = Guid.Parse("1a7706d0-c7e0-11e8-be6c-9116fc548b6b"),
                Created_At = DateTimeOffset.Parse("2018-10-04 14:16:36"),
                Tenant_Id = int.Parse("1"),
                User_Id = int.Parse("1")
            });
            return listModel;
        }

        public static WishListModel GenerateModelHelper()
        {
            WishListModel listModel = new WishListModel();
            listModel.Id = Guid.Parse("4d861070-c7e5-11e8-be6c-9116fc548b6b");
            listModel.Created_At = DateTimeOffset.Parse("2018-10-04 14:53:49");
            listModel.Tenant_Id = int.Parse("1");
            listModel.User_Id = int.Parse("3");

            return listModel;
        }

        public static WishListDTO GenerateDTOHelper()
        {
            WishListDTO listDTO = new WishListDTO();
            listDTO.Id = Guid.Parse("4d861070-c7e5-11e8-be6c-9116fc548b6b");
            listDTO.Created_At = DateTimeOffset.Parse("2018-10-04 14:53:49");
            listDTO.Tenant_Id = int.Parse("1");
            listDTO.User_Id = int.Parse("3");

            return listDTO;
        }
    }
}

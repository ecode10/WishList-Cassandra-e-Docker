using Farfetch.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farfetch.Application.Service.Util
{
    public static class ConvertDTO
    {
        public static void ConvertToListFromDTO(List<Domain.Model.WishListItemModel> list, List<WishListItemDTO> listDTOs)
        {
            foreach (var item in list)
            {
                listDTOs.Add(new WishListItemDTO
                {
                    Id = item.Id,
                    Created_At = item.Created_At,
                    Product_Id = item.Product_Id,
                    Product_Name = item.Product_Name,
                    Quantity = item.Quantity,
                    Updated_At = item.Updated_At
                });
            }
        }

        public static void ConvertToListFromDTO(List<Domain.Model.WishListModel> list, List<WishListDTO> listDTOs)
        {
            if (list != null)
            {
                foreach (var item in list)
                {
                    listDTOs.Add(new WishListDTO
                    {
                        Id = item.Id,
                        Created_At = item.Created_At,
                        Tenant_Id = item.Tenant_Id,
                        User_Id = item.User_Id
                    });
                }
            }
        }

        public static Domain.Model.WishListItemModel ConvertToModel(WishListItemDTO dto)
        {
            var model = new Domain.Model.WishListItemModel();

            if (dto.Id != Guid.Empty)
                model.Id = dto.Id;

            if (dto.Product_Id != Guid.Empty)
                model.Product_Id = dto.Product_Id;

            if (!String.IsNullOrEmpty(dto.Product_Name))
                model.Product_Name = dto.Product_Name;

            if (dto.Quantity != 0)
                model.Quantity = dto.Quantity;

            if (dto.Updated_At != null)
                model.Updated_At = dto.Updated_At;

            return model;
        }

        public static Domain.Model.WishListModel ConvertToModel(WishListDTO dto)
        {
            var model = new Domain.Model.WishListModel();

            if (dto.Id != Guid.Empty)
                model.Id = dto.Id;

            if (dto.User_Id != 0)
                model.User_Id = dto.User_Id;

            if (dto.Tenant_Id != 0)
                model.Tenant_Id = dto.Tenant_Id;

            if (dto.Created_At != null)
                model.Created_At = dto.Created_At;

            return model;
        }
    }
}

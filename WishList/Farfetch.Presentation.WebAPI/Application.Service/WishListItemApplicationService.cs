using Farfetch.Application.DTO;
using Farfetch.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using Farfetch.Application.Service.Util;

namespace Farfetch.Application.Service
{
    public class WishListItemApplicationService
    {
        private IWishListItemData wishListItemData;

        public WishListItemApplicationService(IWishListItemData _wishListItemData)
        {
            wishListItemData = _wishListItemData;
        }

        /// <summary>
        /// Create wish list item by DTO
        /// </summary>
        /// <param name="dto">WishListItemDTO</param>
        /// <returns>Boolean</returns>
        public Boolean CreateWhishListItem(WishListItemDTO dto)
        {
            try
            {
                //convert to model before call the method
                Domain.Model.WishListItemModel model = ConvertDTO.ConvertToModel(dto);

                return wishListItemData.CreateWhishListItem(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        public List<WishListItemDTO> GetAllWhishListItem()
        {
            try
            {
                var list = wishListItemData.GetAllWhishListItem();

                List<WishListItemDTO> listDTOs = new List<WishListItemDTO>();
                ConvertDTO.ConvertToListFromDTO(list, listDTOs);

                return listDTOs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<WishListItemDTO> GetWhishListItemByName(WishListItemDTO dto)
        {
            try
            {
                var list = wishListItemData.GetWhishListItemByName(ConvertDTO.ConvertToModel(dto));

                List<WishListItemDTO> listDTOs = new List<WishListItemDTO>();
                ConvertDTO.ConvertToListFromDTO(list, listDTOs);

                return listDTOs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public WishListItemDTO GetWhishListItemById(WishListItemDTO dto)
        {
            try
            {
                var list = wishListItemData.GetWhishListItemById(ConvertDTO.ConvertToModel(dto));

                List<WishListItemDTO> listDTOs = new List<WishListItemDTO>();
                ConvertDTO.ConvertToListFromDTO(list, listDTOs);
                return listDTOs[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean UpdateWhishListItem(WishListItemDTO dto)
        {
            try
            {
                return wishListItemData.UpdateWhishListItem(ConvertDTO.ConvertToModel(dto));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean DeleteWhishListItem(WishListItemDTO dto)
        {
            try
            {
                return wishListItemData.DeleteWhishListItem(ConvertDTO.ConvertToModel(dto));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

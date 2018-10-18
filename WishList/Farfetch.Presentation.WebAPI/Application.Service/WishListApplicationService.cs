using Farfetch.Application.DTO;
using Farfetch.Application.Service.Util;
using Farfetch.Domain.Core.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Farfetch.Application.Service
{
    public class WishListApplicationService
    {
        private IWishListData _wishListData;

        public WishListApplicationService(IWishListData wishListData)
        {
            _wishListData = wishListData;
        }

        public Boolean CreateWhishList(WishListDTO wishListDTO)
        {
            try
            {
                return _wishListData.CreateWhishList(ConvertDTO.ConvertToModel(wishListDTO));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<WishListDTO> GetAllWhishList()
        {
            try
            {
                var list = _wishListData.GetAllWhishList();

                List<WishListDTO> listDTOs = new List<WishListDTO>();
                ConvertDTO.ConvertToListFromDTO(list, listDTOs);

                return listDTOs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<WishListDTO> GetWhishListById(WishListDTO dto)
        {
            try
            {
                if (dto == null)
                    throw new Exception("Invalid parameters");

                var list = _wishListData.GetWhishListById(ConvertDTO.ConvertToModel(dto));

                List<WishListDTO> listDTOs = new List<WishListDTO>();
                ConvertDTO.ConvertToListFromDTO(list, listDTOs);

                return listDTOs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean UpdateWhishList(WishListDTO dto)
        {
            try
            {
                return _wishListData.UpdateWhishList(ConvertDTO.ConvertToModel(dto));
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Method of delete wish list
        /// </summary>
        /// <param name="itemService">WishListModel</param>
        /// <returns>Boolean</returns>
        public Boolean DeleteWhishList(WishListDTO dto)
        {
            try
            {
                return _wishListData.DeleteWhishList(ConvertDTO.ConvertToModel(dto));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

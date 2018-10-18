using Farfetch.Application.DTO;
using Farfetch.Application.Service;
using Farfetch.Data.Repository;
using Farfetch.Domain.Core.Interface;
using Farfetch.Domain.Model;
using Farfetch.Presentation.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PresentationTest.Helper;
using System;
using System.Collections.Generic;

namespace PresentationTest
{
    [TestClass]
    public class WishListControllerTest
    {
        public IConfiguration configuration { get; set; }

        [TestMethod]
        public void Get_WishList_ReturnListIsNotNull()
        {
            var mock = new Mock<IWishListData>();

            //return expected
            List<WishListModel> listModel = ListModelHelper.GenerateListModelHelper();

            //prepare mock
            mock.Setup(x => x.GetAllWhishList()).Returns(listModel);

            //call class
            WishListApplicationService applicationService = new WishListApplicationService(mock.Object);
            List<WishListDTO> dtos = applicationService.GetAllWhishList();

            //assert is not null
            Assert.IsNotNull(dtos);

            //Assert.IsInstanceOfType(dtos, typeof(OkObjectResult));
            //Assert.IsNotNull(mock.Object);
        }

        [TestMethod]
        public void Get_WishiList_ReturnNotNullAndEmpty()
        {
            var mock = new Mock<IWishListData>();

            WishListModel listModel = ListModelHelper.GenerateModelHelper();

            mock.Setup(x => x.GetWhishListById(listModel));

            WishListApplicationService applicationService = new WishListApplicationService(mock.Object);
            var dto = applicationService.GetWhishListById(ListModelHelper.GenerateDTOHelper());

            //var badRequest = result as BadRequestObjectResult;

            Assert.IsNotNull(dto);
            //Assert.("Invalid parameters", badRequest.Value);
            //Assert.IsInstanceOfType(dto, typeof(BadRequestObjectResult));
            Assert.IsNotInstanceOfType(dto, typeof(BadRequestObjectResult));
        }
    }
}

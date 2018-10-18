using Farfetch.Application.DTO;
using Farfetch.Application.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Farfetch.Application.Service.Util;
using System;
using System.Net.Http;

namespace Farfetch.Presentation.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly WishListApplicationService _wishListApplicationService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationService"></param>
        public WishListController(WishListApplicationService applicationService)
        {
            this._wishListApplicationService = applicationService;
        }

        // GET api/getwishlist
        [Route("GetWishList")]
        [HttpGet]
        public IActionResult GetWishList()
        {
            var result = _wishListApplicationService.GetAllWhishList();
            return Ok(result);
        }

        // GET api/getwishlist/123 {guid}
        [Route("GetWishList/{id}")]
        [HttpGet]
        public IActionResult GetWishList(Guid id)
        {
            WishListDTO dto = new WishListDTO();
            if (id == Guid.Empty || id == null)
                return BadRequest("Invalid parameters");

            dto.Id = id;

            return Ok(_wishListApplicationService.GetWhishListById(dto));
        }


        // DELETE api/deletewishlist/123 {guid}
        [Route("DeleteWishList/{id}")]
        [HttpDelete]
        public ActionResult DeleteWishList(Guid id)
        {
            WishListDTO dto = new WishListDTO();
            if (id != Guid.Empty)
                dto.Id = id;

            if (_wishListApplicationService.DeleteWhishList(dto))
                return Ok();
            else
                return NotFound();
        }

        // PUT api/putwishlist/123 {guid}
        [Route("PutWishList/{id}")]
        [HttpPut]
        public ActionResult PutWishList(Guid id, [FromBody] WishListDTO wishListDTO)
        {
            if (wishListDTO != null)
            {
                if (_wishListApplicationService.UpdateWhishList(wishListDTO))
                    return CreatedAtAction("GetWishList", new { id = wishListDTO.Id }, wishListDTO);
                else
                    return NotFound();
            }
            else
                return NotFound();
        }

        // POST api/postwishlist/ {guid}
        [Route("PostWishList")]
        [HttpPost]
        public ActionResult PostWishList([FromBody] WishListDTO wishListDTO)
        {
            if (wishListDTO != null)
            {
                if (_wishListApplicationService.CreateWhishList(wishListDTO))
                    return CreatedAtAction("GetWishList", new { id = wishListDTO.Id }, wishListDTO);
                else
                    return NotFound();
            }
            else
                return NotFound();
        }
    }
}
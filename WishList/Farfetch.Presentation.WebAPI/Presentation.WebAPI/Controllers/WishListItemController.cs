using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Farfetch.Application.DTO;
using Farfetch.Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Farfetch.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListItemController : ControllerBase
    {
        private readonly WishListItemApplicationService _wishListItemApplicationService;

        public WishListItemController(WishListItemApplicationService listItemApplicationService)
        {
            _wishListItemApplicationService = listItemApplicationService;
        }

        // GET api/getwishlistitem
        [Route("GetWishListItem")]
        [HttpGet]
        public IActionResult GetWishListItem()
        {
            var result = _wishListItemApplicationService.GetAllWhishListItem();
            return Ok(result);
        }

        // GET api/getwishlist/123 {guid}
        [Route("GetWishListItem/{id}")]
        [HttpGet]
        public IActionResult GetWishListItem(Guid id)
        {
            WishListItemDTO dto = new WishListItemDTO();

            if (id == Guid.Empty || id == null)
                return this.BadRequest("Invalid parameter");

            dto.Id = id;
            var result = _wishListItemApplicationService.GetWhishListItemById(dto);

            return Ok(result);
        }


        // DELETE api/deletewishlistitem/123 {guid}
        [Route("DeleteWishListItem/{id}")]
        [HttpDelete]
        public ActionResult DeleteWishListItem(Guid id)
        {
            WishListItemDTO dto = new WishListItemDTO();
            if (id != Guid.Empty)
                dto.Id = id;

            if (_wishListItemApplicationService.DeleteWhishListItem(dto))
                return Ok();
            else
                return NotFound();
        }

        // PUT api/putwishlistitem/123 {guid}
        [Route("PutWishListItem/{id}")]
        [HttpPut]
        public ActionResult PutWishListItem(Guid id, [FromBody] WishListItemDTO wishListItemDTO)
        {
            if (wishListItemDTO != null)
            {
                if (_wishListItemApplicationService.UpdateWhishListItem(wishListItemDTO))
                    return CreatedAtAction("GetWishListItem", new { id = wishListItemDTO.Id }, wishListItemDTO);
                else
                    return NotFound();
            }
            else
                return NotFound();
        }

        // POST api/postwishlist/ {guid}
        [Route("PostWishListItem")]
        [HttpPost]
        public ActionResult PostWishListItem([FromBody] WishListItemDTO wishListItemDTO)
        {
            if (wishListItemDTO != null)
            {
                if (_wishListItemApplicationService.CreateWhishListItem(wishListItemDTO))
                    return CreatedAtAction("GetWishListItem", new { id = wishListItemDTO.Id }, wishListItemDTO);
                else
                    return NotFound();
            }
            else
                return NotFound();
        }
    }
}
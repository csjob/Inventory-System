using InventorySystem.Models.EntityModel;
using InventorySystem.Repository.Interface;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace InventorySystem.Controllers.API
{
    [RoutePrefix("api/item")]
    public class ItemAPIController : ApiController
    {
        private readonly IItemMethod _itemMethod;
        public ItemAPIController(IItemMethod itemMethod)
        {
            _itemMethod = itemMethod;
        }

        [Route("add", Name = "I-Add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddItem(ItemMaster data)
        {
            if(ModelState.IsValid) 
                return Ok(await _itemMethod.AddItem(data));
            return BadRequest("Invalid Data");
        }

        //[Route("get-item-type", Name ="I-GetTypeList")]
        //[HttpGet]
        //public async Task<IHttpActionResult> GetItemTypeList()
        //{
        //    return Ok(await _itemMethod.GetItemTypeList());
        //}

        [Route("get-item", Name ="I-GetItemList")]
        [HttpGet]
        public async Task<IHttpActionResult> GetItemList()
        {
            return Ok(await _itemMethod.GetItemList());
        }

        [Route("get-product-info/{itemId}", Name ="T-GetItemInfo")]
        [HttpGet]
        public async Task<IHttpActionResult> GetProductInfo(int itemId)
        {
            if (itemId > 0) return Ok(await _itemMethod.GetItemInfo(itemId));
            return BadRequest();
        }

    }
}
using InventorySystem.Models.EntityModel;
using InventorySystem.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace InventorySystem.Repository.Interface
{
    public interface IItemMethod
    {
        Task<BaseResponse> AddItem(ItemMaster data);
        //Task<List<SelectListItem>> GetItemTypeList();
        Task<List<SelectListItem>> GetItemList();
        Task<ItemMaster> GetItemInfo(int itemId);
    }
}

using InventorySystem.Models.DataModel;
using InventorySystem.Models.EntityModel;
using InventorySystem.Models.Response;
using InventorySystem.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace InventorySystem.Repository.Service
{
    public class ItemMethod : IItemMethod
    {
        public async Task<BaseResponse> AddItem(ItemMaster data)
        {
			BaseResponse response= new BaseResponse();
			try
			{
                using (var dbContext = new AppDbContext())
                {
                    bool itemNameExists = await dbContext.ItemMasters.AnyAsync(item => item.ItemName.Trim().ToUpper() == data.ItemName.Trim().ToUpper());
                    if (itemNameExists) response.Message = "Item Name Already Exists.";
                    else
                    {
                        data.InDate = DateTime.Now;
                        dbContext.ItemMasters.Add(data);
                        dbContext.SaveChanges();
                        response.Status = true;
                        response.Message = "Item added successfully.";
                    }
                    
                }
            }
			catch (Exception ex)
			{
                response.Message = ex.Message;
			}
			return response;
        }

        //public async Task<List<SelectListItem>> GetItemTypeList()
        //{
        //    using(var dbContext = new AppDbContext())
        //    {
        //        List<ItemType> types = await dbContext.ItemTypes.ToListAsync();
        //        return types.Select(item => new SelectListItem
        //        {
        //            Value= item.TId.ToString(),
        //            Text = item.TypeName                 
        //        }).ToList();
        //    }
        //}

        public async Task<List<SelectListItem>> GetItemList()
        {
            using(var dbContext = new AppDbContext())
            {
                List<ItemMaster> items = await dbContext.ItemMasters.ToListAsync();
                return items.Select(item => new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.ItemName.ToString(),
                }).ToList();
            }
        }   

        public async Task<ItemMaster> GetItemInfo(int itemId)
        {
            try
            {
                using (var dbContext = new AppDbContext())
                {
                    return await dbContext.ItemMasters.FindAsync(itemId);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
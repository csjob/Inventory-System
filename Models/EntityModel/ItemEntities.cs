using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventorySystem.Models.EntityModel
{
    [Table("itemmaster")]  
    
    public class ItemMaster
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string ItemName { get; set; }       

        public int? AmountPerKg { get; set; }

        public DateTime? InDate { get; set; }        
    }

}
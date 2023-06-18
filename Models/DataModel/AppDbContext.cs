using InventorySystem.Models.EntityModel;
using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InventorySystem.Models.DataModel
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("connectionString") 
        { }

        public DbSet<ItemMaster> ItemMasters { get; set; }        

    }
}
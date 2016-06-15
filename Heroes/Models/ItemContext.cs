using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Heroes.Models
{
    public class ItemContext: DbContext
    {
        public DbSet<Item> ItemsList { get; set; }
        public DbSet<Hero> HeroesList { get; set; }

        public ItemContext()
            : base("ItemContext")
        {
        }

        public static ItemContext Create()
        {
            return new ItemContext();
        }

    }
}
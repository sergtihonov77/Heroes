using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heroes.Models
{
    public class ItemRepository
    {
        private ItemContext context = new ItemContext();

        public IEnumerable<Hero> Heroes
        {
            get { return context.HeroesList; }
        }

        public IEnumerable<Item> Items
        {
            get { return context.ItemsList; }
        }
    }
}
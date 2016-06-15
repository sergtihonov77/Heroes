using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heroes.Models
{

    public class Item
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Mark { get; set; }
        public Clases ItemClass { get; set; }
        public string IconUri { get; set; }
        public int PurchacePrace { get; set; }
        public int SalePrice { get; set; }

        public int Health { get; set; }
        public int Mann { get; set; }
        public int Armor { get; set; }
        public int Power { get; set; }
        public int Ability { get; set; }
        public int Intelligence { get; set; }
    }
}
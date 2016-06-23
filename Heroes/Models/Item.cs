using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Heroes.Models
{

    public class Item
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Описание:")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Название предмета:")]
        public string Mark { get; set; }

        [Display(Name = "Класс предмета:")]
        public Clases ItemClass { get; set; }

        public string IconUri { get; set; }

        [Required]
        [Display(Name = "Цена покупки:")]
        public int PurchacePrace { get; set; }

        [Required]
        [Display(Name = "Цена продажи:")]
        public int SalePrice { get; set; }

        [Required]
        [Display(Name = "Здоровье:")]
        public int Health { get; set; }

        [Required]
        [Display(Name = "Манна:")]
        public int Mann { get; set; }

        [Required]
        [Display(Name = "Защита:")]
        public int Armor { get; set; }

        [Required]
        [Display(Name = "Сила:")]
        public int Power { get; set; }

        [Required]
        [Display(Name = "Ловкость:")]
        public int Ability { get; set; }

        [Required]
        [Display(Name = "Интеллект:")]
        public int Intelligence { get; set; }

        public int? HeroId { get; set; }

        public Hero Hero { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Heroes.Models
{
    public class Hero
    {
       
        public int HeroId { get; set; }

        [Display(Name = "Имя:")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Расса:")]
        public Races Race { get; set; }

        [Required]
        [Display(Name = "Класс:")]
        public Clases Class { get; set; }

        [Required]
        [Display(Name = "Колличество золота:")]
        public int Gold { get; set; }

        public string AvatarUri { get; set; }

        [Required]
        [Display(Name = "Здоровье:")]
        public int Health { get; set; }

        [Required]
        [Display(Name = "Манна:")]
        public int Mann { get; set; }

        [Required]
        [Display(Name = "Защита:")]
        public int Armor { get; set;}

        [Required]
        [Display(Name = "Сила:")]
        public int Power { get; set; }

        [Required]
        [Display(Name = "Ловкость:")]
        public int Ability { get; set; }

        [Required]
        [Display(Name = "Интеллект:")]
        public int Intelligence { get; set; }

        [Required]
        [Display(Name = "Описание:")]
        public string Description { get; set; }

        public string UserName { get; set; }
        
        public ICollection<Item> Items { get; set; }

        public Hero()
        {
            Items = new List<Item>();
        }
    }

    public enum Races
    {
        Human = 1,
        Elf = 2,
        Undead = 3,
        Orc = 4
    }

    public enum Clases
    {
        Warior = 1,
        Wizard = 2,
        Archer = 3,
        Healer = 4
    }
}
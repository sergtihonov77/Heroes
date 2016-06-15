using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Heroes.Models
{
    public class Hero
    {
        public int HeroId { get; set; }

        [Display(Name = "Имя:")]
        public string Name { get; set; }

        [Display(Name = "Расса:")]
        public Races Race { get; set; }

        [Display(Name = "Класс:")]
        public Clases Class { get; set; }

        [Display(Name = "Колличество золота:")]
        public int Gold { get; set; }

        public string AvatarUri { get; set; }

        [Display(Name = "Здоровье:")]
        public int Health { get; set; }

        [Display(Name = "Манна:")]
        public int Mann { get; set; }

        [Display(Name = "Защита:")]
        public int Armor { get; set;}

        [Display(Name = "Сила:")]
        public int Power { get; set; }

        [Display(Name = "Ловкость:")]
        public int Ability { get; set; }

        [Display(Name = "Интеллект:")]
        public int Intelligence { get; set; }

        [Display(Name = "Описание:")]
        public string Description { get; set; }


        public DbSet<Item> Items { get; set; }
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
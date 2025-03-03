using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WerehouseManagement.Models
{
    public class Товар
    {
        public int ID_Товара { get; set; }
        public string Название { get; set; }
        public string Артикул { get; set; }
        public string Штрихкод { get; set; }
        public string Категория { get; set; }
        public string Единица_измерения { get; set; }
        public decimal Цена_за_единицу { get; set; }
        public string Серийный_номер { get; set; }
        public int Минимальный_остаток { get; set; }

        public Товар(Товары товары)
        {
            ID_Товара = товары.ID_Товара;
            Название = товары.Название;
            Артикул = товары.Артикул;
            Штрихкод = товары.Штрихкод;
            Категория = товары.Категория;
            Единица_измерения = товары.Единица_измерения;
            Цена_за_единицу = товары.Цена_за_единицу;
            Серийный_номер = товары.Серийный_номер;
            Минимальный_остаток = товары.Минимальный_остаток;
        }
    }
}
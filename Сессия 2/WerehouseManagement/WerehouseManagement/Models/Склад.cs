using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WerehouseManagement.Models
{
    public class Склад
    {
        public int ID_Склада { get; set; }
        public string Название_Склада { get; set; }
        public string Адрес { get; set; }
        public string Тип_Склада { get; set; }
        public string Зона_Хранения { get; set; }
    }
}
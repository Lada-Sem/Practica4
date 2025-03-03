using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibWarehouse
{
    public class СкладскойАнализатор
    {
        private readonly СкладскойУчетEntities _context; // Замените на ваш DataContext

        public СкладскойАнализатор(СкладскойУчетEntities context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #region Подсчет количества товаров
        // 1. Подсчет количества товаров (общее) по складам (один товар на всех складах)
        public int CountTotalProductsByWarehouse(int warehouseId)
        {
            return _context.Остатки_На_Складе
                .Where(o => o.ID_Склада == warehouseId)
                .Sum(o => o.Текущее_Количество);
        }

        // 1. Подсчет количества товаров на складе (сумма позиций)
        public int CountTotalProductsInWarehouse()
        {
            return _context.Остатки_На_Складе.Sum(o => o.Текущее_Количество);
        }

        // Перегрузка метода для подсчета конкретного товара на всех складах
        public int CountProductInAllWarehouses(int productId)
        {
            return _context.Остатки_На_Складе
                .Where(o => o.ID_Товара == productId)
                .Sum(o => o.Текущее_Количество);
        }
        #endregion

        #region Подсчет суммы стоимости товаров
        // 2. Подсчет суммы стоимости товаров на складе
        public decimal CalculateTotalValueInWarehouse(int warehouseId)
        {
            return _context.Остатки_На_Складе
                .Where(o => o.ID_Склада == warehouseId)
                .Join(_context.Товары,
                       остаток => остаток.ID_Товара,
                       товар => товар.ID_Товара,
                       (остаток, товар) => new { остаток, товар })
                .Sum(x => x.остаток.Текущее_Количество * x.товар.Цена_за_единицу);
        }

        // 2. Подсчет суммы стоимости товаров по складам
        public decimal CalculateTotalValueAllWarehouses()
        {
            return _context.Остатки_На_Складе
                .Join(_context.Товары,
                      остаток => остаток.ID_Товара,
                      товар => товар.ID_Товара,
                      (остаток, товар) => new { остаток, товар })
                .Sum(x => x.остаток.Текущее_Количество * x.товар.Цена_за_единицу);
        }
        #endregion

        #region Подсчет товара по категориям
        // 3. Подсчет товара по категориям на складе
        public int CountProductsByCategoryInWarehouse(int warehouseId, string category)
        {
            return _context.Остатки_На_Складе
                .Where(o => o.ID_Склада == warehouseId)
                .Join(_context.Товары,
                      остаток => остаток.ID_Товара,
                      товар => товар.ID_Товара,
                      (остаток, товар) => new { остаток, товар })
                .Where(x => x.товар.Категория == category)
                .Sum(x => x.остаток.Текущее_Количество);
        }

        // 3. Подсчет товара по категориям по складам
        public int CountProductsByCategoryAllWarehouses(string category)
        {
            return _context.Остатки_На_Складе
                .Join(_context.Товары,
                      остаток => остаток.ID_Товара,
                      товар => товар.ID_Товара,
                      (остаток, товар) => new { остаток, товар })
                .Where(x => x.товар.Категория == category)
                .Sum(x => x.остаток.Текущее_Количество);
        }
        #endregion
    }
}
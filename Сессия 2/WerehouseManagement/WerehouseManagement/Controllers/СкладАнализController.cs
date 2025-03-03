using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibWarehouse;

namespace WerehouseManagement.Controllers
{
    public class СкладАнализController : Controller
    {

        // GET: СкладАнализ
        public ActionResult Index()
        {
            using (var context = new СкладскойУчетEntities()) // Замените на ваш DataContext
            {
                var warehouseInfo = new СкладскойАнализатор(context);

                // Пример использования методов:
                int totalProducts = warehouseInfo.CountTotalProductsInWarehouse();
                decimal totalValue = warehouseInfo.CalculateTotalValueAllWarehouses();

                ViewBag.TotalProducts = totalProducts;
                ViewBag.TotalValue = totalValue;

                return View();
            }
        }
    }
}
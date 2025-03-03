using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WerehouseManagement.Models;
using LibWarehouse;

namespace WerehouseManagement.Controllers
{
    [RoutePrefix("api/АнализСклада")]
    public class АнализСкладаController : ApiController
    {
        private readonly СкладскойУчетEntities _context;
        private readonly СкладскойАнализатор _warehouseInfo;

        public АнализСкладаController()
        {
            _context = new СкладскойУчетEntities(); // Создайте экземпляр вашего DataContext
            _warehouseInfo = new СкладскойАнализатор(_context);
        }

        // GET api/АнализСклада/КоличествоТоваров/Склад/{warehouseId}
        [HttpGet]
        [Route("КоличествоТоваров/Склад/{warehouseId}")]
        public IHttpActionResult GetTotalProductsByWarehouse(int warehouseId)
        {
            try
            {
                int count = _warehouseInfo.CountTotalProductsByWarehouse(warehouseId);
                return Ok(count);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                return InternalServerError(ex);
            }
        }

        // GET api/АнализСклада/КоличествоТоваров/Общее
        [HttpGet]
        [Route("КоличествоТоваров/Общее")]
        public IHttpActionResult GetTotalProducts()
        {
            try
            {
                int count = _warehouseInfo.CountTotalProductsInWarehouse();
                return Ok(count);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                return InternalServerError(ex);
            }
        }

        // GET api/АнализСклада/Стоимость/Склад/{warehouseId}
        [HttpGet]
        [Route("Стоимость/Склад/{warehouseId}")]
        public IHttpActionResult GetTotalValueByWarehouse(int warehouseId)
        {
            try
            {
                decimal value = _warehouseInfo.CalculateTotalValueInWarehouse(warehouseId);
                return Ok(value);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                return InternalServerError(ex);
            }
        }

        // GET api/АнализСклада/Стоимость/Общее
        [HttpGet]
        [Route("Стоимость/Общее")]
        public IHttpActionResult GetTotalValue()
        {
            try
            {
                decimal value = _warehouseInfo.CalculateTotalValueAllWarehouses();
                return Ok(value);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                return InternalServerError(ex);
            }
        }

        // GET api/АнализСклада/Категория/Склад/{warehouseId}/{category}
        [HttpGet]
        [Route("Категория/Склад/{warehouseId}/{category}")]
        public IHttpActionResult GetProductsByCategoryInWarehouse(int warehouseId, string category)
        {
            try
            {
                int count = _warehouseInfo.CountProductsByCategoryInWarehouse(warehouseId, category);
                return Ok(count);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                return InternalServerError(ex);
            }
        }

        // GET api/АнализСклада/Категория/Общее/{category}
        [HttpGet]
        [Route("Категория/Общее/{category}")]
        public IHttpActionResult GetProductsByCategory(string category)
        {
            try
            {
                int count = _warehouseInfo.CountProductsByCategoryAllWarehouses(category);
                return Ok(count);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                return InternalServerError(ex);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}


      /* private readonly СкладАнализРасчет _сервис;

        public АнализСкладаController()
        {
            _сервис = new СкладАнализРасчет();
        }

        // GET: api/СкладАнализ/ОбщееКоличество
        [Route("ОбщееКоличество")]
        public IHttpActionResult GetОбщееКоличество()
        {
            try
            {
                var общее_количество = _сервис.ПодсчитатьОбщееКоличество();
                return Ok(общее_количество);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); // Возвращаем ошибку, если она возникла
            }
        }

        // GET: api/СкладАнализ/ОбщаяСумма
        [Route("ОбщаяСумма")]
        public IHttpActionResult GetОбщаяСумма()
        {
            try
            {
                var общая_сумма = _сервис.ПодсчитатьОбщуюСумму();
                return Ok(общая_сумма);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); // Возвращаем ошибку, если она возникла
            }
        }

        // GET: api/СкладАнализ/Категории
        [Route("Категории")]
        public IHttpActionResult GetКатегории()
        {
            try
            {
                var категории = _сервис.ПодсчитатьКатегории();
                return Ok(категории);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); // Возвращаем ошибку, если она возникла
            }
        }*/
    
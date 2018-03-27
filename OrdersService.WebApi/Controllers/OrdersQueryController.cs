﻿using Microsoft.AspNetCore.Mvc;
using OrdersService.WebApi.Models;

namespace OrdersService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class OrdersQueryController : Controller
    {
        private readonly IOrdersPresenter _ordersPresenter;

        public OrdersQueryController(IOrdersPresenter ordersPresenter)
        {
            _ordersPresenter = ordersPresenter;
        }

        [HttpGet("list/{page:int?}")]
        public OkObjectResult GetByPage(int? page)
        {
            var result = _ordersPresenter.GetByPage(page ?? 1);

            return Ok(result);
        }

        [HttpGet("id/{id}")]
        public ActionResult GetById(string id)
        {
            var model = _ordersPresenter.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }
    }
}
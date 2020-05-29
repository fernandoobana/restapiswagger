﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi_Swagger.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private List<Product> _listProducts = null;

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            _listProducts = new List<Product>();
            _listProducts.Add(
                new Product { Id = 1, Price = 25.90M, Description = "Produto 1" }
            );
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _listProducts.ToArray();
        }

        [HttpPost]
        public void Post([FromBody]Product product)
        {
            _listProducts.Add(product);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Route("getById")]
        public IActionResult GetById(int id)
        {
            var prod = _listProducts.Where(p => p.Id == id);
            if (prod != null && prod.Count() > 0)
            {
                return Ok(prod);
            }

            return NotFound();
        }
    }
}

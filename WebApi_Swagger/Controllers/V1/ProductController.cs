using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Swagger.Data;
using WebApi_Swagger.Helpers;

namespace WebApi_Swagger.Controllers.V1
{
    /// <summary>
    /// Versão 1 da controller Product
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly DataContext _dataContext;

        /// <summary>
        ///
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="dataContext"></param>
        public ProductController(ILogger<ProductController> logger, DataContext dataContext)
        {
            _logger = logger;
            _dataContext = dataContext;
        }

        /// <summary>
        /// Método responsável por retornar todos os produtos
        /// </summary>
        /// <returns>Lista de produtos</returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageParams pageParams)
        {
            var products = await GetProducts(pageParams);

            Response.AddPagination(products.CurrentPage, products.PageSize, products.TotalCount, products.TotalPages);

            return Ok(products);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            _dataContext.Products.Add(product);
            _dataContext.SaveChanges();

            return Ok(product);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Route("getById")]
        public IActionResult GetById(int id)
        {
            var prod = _dataContext.Products.Where(p => p.Id == id);
            if (prod != null && prod.Count() > 0)
            {
                return Ok(prod);
            }

            return NotFound();
        }

        private async Task<PageList<Product>> GetProducts(PageParams pageParams)
        {
            IQueryable<Product> query = _dataContext.Products;

            if (pageParams.IdFilter > 0)
            {
                query = query.Where(x => x.Id == pageParams.IdFilter);
            }

            query = query.AsNoTracking().OrderBy(x => x.Id);

            return await PageList<Product>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }
    }
}

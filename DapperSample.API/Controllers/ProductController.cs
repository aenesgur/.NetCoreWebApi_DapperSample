using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperSample.BLL.Managers.Interfaces;
using DapperSample.BLL.Models;
using DapperSample.DAL.Services.Interfaces;
using DapperSample.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperSample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductManager _productManager;
        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var productList = await _productManager.Get();
            return StatusCode(200, productList);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var responseModel = await _productManager.Delete(id);
            return StatusCode(responseModel.StatusCode, responseModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            var responseModel = await _productManager.Create(product);
            return StatusCode(responseModel.StatusCode, responseModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var product = await _productManager.Get(id);
            if (product == null)
                return StatusCode(404);

            return StatusCode(200, product);
        }

        

        

    }
}

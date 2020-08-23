using DapperSample.BLL.Managers.Interfaces;
using DapperSample.BLL.Models;
using DapperSample.DAL.Services.Interfaces;
using DapperSample.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DapperSample.BLL.Managers
{
    public class ProductManager : IProductManager
    {
        private IProductService _productService;
        public ProductManager(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ResponseModel> Create(Product product)
        {
            var isCreated = await _productService.Create(product);
            if (!isCreated)
            {
                return new ResponseModel
                {
                    StatusCode = 400,
                    Message = "Something went wrong with deleted"
                };
            }

            return new ResponseModel
            {
                StatusCode = 204,
            };
        }

        public async Task<ResponseModel> Delete(int id)
        {
            var isDeleted = await _productService.Delete(id);
            if (!isDeleted)
            {
                return new ResponseModel
                {
                    StatusCode = 400,
                    Message = "There is no product with realted that id in DB"
                };
            }

            return new ResponseModel
            {
                StatusCode = 204,
            };

        }

        public async Task<List<Product>> Get()
        {
            return await _productService.Get();
        }

        public async Task<Product> Get(int id)
        {
            return await _productService.Get(id);
        }
    }
}

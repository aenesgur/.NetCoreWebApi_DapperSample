using DapperSample.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DapperSample.DAL.Services.Interfaces
{
    public interface IProductService
    {
        Task<bool> Create(Product product);
        Task<List<Product>> Get();
        Task<Product> Get(int id);
        Task<bool> Delete(int id);
    }
}

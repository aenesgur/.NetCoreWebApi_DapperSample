using DapperSample.BLL.Models;
using DapperSample.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DapperSample.BLL.Managers.Interfaces
{
    public interface IProductManager
    {
        Task<ResponseModel> Create(Product product);
        Task<List<Product>> Get();
        Task<Product> Get(int id);
        Task<ResponseModel> Delete(int id);
    }
}

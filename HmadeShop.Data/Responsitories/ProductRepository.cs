using HmadeShop.Data.Infrastructure;
using HmadeShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmadeShop.Data.Responsitories
{
    public interface IProductRepository:IRepository<Product>
    {

    }
    public class ProductRepository: RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(DbFactory dbFactory)
            : base(dbFactory)
        {


        }
    }
}

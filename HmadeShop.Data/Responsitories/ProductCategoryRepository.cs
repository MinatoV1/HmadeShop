using HmadeShop.Data.Infrastructure;
using HmadeShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmadeShop.Data.Responsitories
{
    public interface IProductCategoryRepository: IRepository<ProductCategory>
    {
        IEnumerable<ProductCategory> GetByAlias(string alias);
    }
    class ProductCategoryRepository : RepositoryBase<ProductCategory>
    {
        public ProductCategoryRepository(DbFactory dbFactory)
            : base(dbFactory)
        {


        }

        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            return this.DbContext.ProductCategories.Where(x => x.Alias == alias);
        }
    }
}

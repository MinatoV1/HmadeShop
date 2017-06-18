using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmadeShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private HmadeShopDbContext dbContext;
        public HmadeShopDbContext Init()
        {
            return dbContext ?? (dbContext = new HmadeShopDbContext());
        }

        protected override void DisposeCore()
        {
            if(dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}

using HmadeShop.Data.Infrastructure;
using HmadeShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmadeShop.Data.Responsitories
{
    public interface IErrorRepository : IRepository<Error>
    {
    }

    public class ErrorRepository : RepositoryBase<Error>, IErrorRepository
    {
        public ErrorRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

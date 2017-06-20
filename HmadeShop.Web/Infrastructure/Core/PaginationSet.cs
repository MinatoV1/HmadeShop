using System.Collections.Generic;
using System.Linq;

namespace HmadeShop.Web.Infrastructure.Core
{
    //dùng để phân trang
    public class PaginationSet<T>
    {
        public int Page { set; get; }

        public int Count
        {
            get
            {
                return (Items != null) ? Items.Count() : 0;
            }
        }

        public int TotalPages { set; get; }
        public int TotalCount { set; get; }
        public IEnumerable<T> Items { set; get; }
    }
}
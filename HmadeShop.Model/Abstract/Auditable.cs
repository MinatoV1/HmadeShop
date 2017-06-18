using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmadeShop.Model.Abstract
{
    public abstract class Auditable: IAuditable
    {

       public DateTime? CreatedDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        //khai báo interface ko có public private
        public string MetaKeyword { set; get; }
        public string MetaDescription { set; get; }

        public bool Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmadeShop.Model.Abstract
{
    public interface IAuditable
    {
       
        DateTime? CreatedDate { get; set; }
        [MaxLength(256)]
        string CreateBy { get; set; }
        DateTime? UpdateDate { get; set; }
        [MaxLength(256)]
        string UpdateBy { get; set; }

        [MaxLength(256)]
        string MetaKeyword { set; get; }
        [MaxLength(256)]
        string MetaDescription { set; get; }

        bool Status { get; set; }
        //khai báo interface ko có public private
    }
}

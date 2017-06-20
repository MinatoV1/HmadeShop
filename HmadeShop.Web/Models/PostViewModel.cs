using HmadeShop.Web.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HmadeShop.Web.Models
{
    public class PostViewModel
    {
     
        public int ID { get; set; }


        public string Name { get; set; }


        public string Alias { get; set; }

        public int CategoryID { get; set; }
        public string Image { get; set; }

        public string MoreImages { set; get; }

        public decimal Price { set; get; }
        public decimal? PromotionPrice { set; get; }
        public int? Warranty { get; set; }
        public string Description { set; get; }
        public string Content { get; set; }
        public bool? HomeFlag { set; get; }
        public bool? HotFlag { set; get; }
        public int? ViewCount { set; get; }

        public DateTime? CreatedDate { set; get; }


        public string CreatedBy { set; get; }

        public DateTime? UpdatedDate { set; get; }


        public string UpdatedBy { set; get; }

        public string MetaKeyword { set; get; }


        public string MetaDescription { set; get; }

        public bool Status { set; get; }


        public virtual ProductCategoryViewModel ProductCategory { get; set; }
    }
}
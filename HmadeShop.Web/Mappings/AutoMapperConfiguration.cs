using AutoMapper;
using HmadeShop.Model.Models;
using HmadeShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HmadeShop.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Post, PostViewModel>();
            Mapper.CreateMap<PostCategory, PostCategoryViewModel>();
       
            Mapper.CreateMap<PostTag, PostTagViewModel>();

            Mapper.CreateMap<ProductCategory, ProductCategoryViewModel>();
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<ProductTag, ProductTagViewModel>();

            Mapper.CreateMap<Tag, TagViewModel>();
        }
    }
}
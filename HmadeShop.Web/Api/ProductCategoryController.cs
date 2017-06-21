using AutoMapper;
using HmadeShop.Model.Models;
using HmadeShop.Service;
using HmadeShop.Web.Infrastructure.Core;
using HmadeShop.Web.Infrastructure.Extensions;
using HmadeShop.Web.Mappings;
using HmadeShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HmadeShop.Web.Api
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        IProductCategoryService _productCategoryService;
        public ProductCategoryController(IErrorService errorService, IProductCategoryService postCategoryService) : base(errorService)
        {
            this._productCategoryService = postCategoryService;

        }
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request, string keyword,int page, int pageSize)
        {
            return CreateHttpResponse(request, () =>
            {
                //Phân trang
                int totalRow = 0;

                //var model = _productCategoryService.GetAll(); thằng này get tất cả
                var model = _productCategoryService.GetAll(keyword); //thằng này có từ khóa search

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(query);

                //Phân trang
                var paginationSet = new PaginationSet<ProductCategoryViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };


                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }

        [Route("getallparent")]
        [HttpGet]
        public HttpResponseMessage GetParentProductCategory(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
               
                var model = _productCategoryService.GetAll();// thằng này get tất cả

                var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductCategoryViewModel productCategory)
        {
            return CreateHttpResponse(request, () =>
             {
                 HttpResponseMessage response = null;
                 if(!ModelState.IsValid)
                 {
                     response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                 }
                 else
                 {
                     var newProductCategory = new ProductCategory();
                     newProductCategory.UpdateProductCategory(productCategory);
                     _productCategoryService.Add(newProductCategory);
                     _productCategoryService.Save();

                     var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(newProductCategory);

                     response = request.CreateResponse(HttpStatusCode.Created, responseData);

                 
                 }
                 return response;

             });
        }


    }
}

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


    }
}

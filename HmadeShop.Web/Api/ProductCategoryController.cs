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
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productCategoryService.GetAll();
                var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });



        }

        
    }
}

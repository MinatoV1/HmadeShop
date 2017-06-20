using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HmadeShop.Web.Api
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            string json = @"[
                              {
                                'Name': 'Product 1',
                                 'ExpiryDate': '2000-12-29T00:00Z',
                                 'Price': 99.95,
                                 'Sizes': null
                               },
                               {
                                 'Name': 'Product 2',
                                'ExpiryDate': '2009-07-31T00:00Z',
                                'Price': 12.50,
                                'Sizes': null
                              }
                            ]";
            var res = request.CreateResponse(HttpStatusCode.OK,json);
            return res;
        }

    }
}

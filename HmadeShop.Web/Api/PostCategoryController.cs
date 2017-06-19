using AutoMapper;
using HmadeShop.Model.Models;
using HmadeShop.Service;
using HmadeShop.Web.Infrastructure.Core;
using HmadeShop.Web.Infrastructure.Extensions;
using HmadeShop.Web.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HmadeShop.Web.Api
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        IPostCategoryService _postCategoryService;
        public PostCategoryController(IErrorService erorService, IPostCategoryService postCategoryService) : base(erorService)
        {
            this._postCategoryService = postCategoryService;

        }
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpRespone(request, () =>
            {

                var category = _postCategoryService.GetAll();

                var listPostCategortVM = Mapper.Map<List<PostCategoryViewModel>>(category);

                HttpResponseMessage reponse = request.CreateResponse(HttpStatusCode.OK, category);

                return reponse;
            });
        }

        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategoryViewModel postCategoryVM)
        {
            return CreateHttpRespone(request, () =>
            {
                HttpResponseMessage reponse = null;
                if (ModelState.IsValid)
                {
                    reponse = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    PostCategory newPostCategory = new PostCategory();
                    newPostCategory.UpdatePostCategory(postCategoryVM);

                    var category = _postCategoryService.Add(newPostCategory);
                    _postCategoryService.Save();

                    reponse = request.CreateResponse(HttpStatusCode.Created, category);
                }
                return reponse;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategoryViewModel postCategoryVM)
        {
            return CreateHttpRespone(request, () =>
            {
                HttpResponseMessage reponse = null;
                if (ModelState.IsValid)
                {
                    reponse = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var postCategoryDb = _postCategoryService.GetById(postCategoryVM.ID);
                    postCategoryDb.UpdatePostCategory(postCategoryVM);

                    _postCategoryService.Update(postCategoryDb);
                    _postCategoryService.Save();

                    reponse = request.CreateResponse(HttpStatusCode.OK);
                }
                return reponse;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpRespone(request, () =>
            {
                HttpResponseMessage reponse = null;
                if (ModelState.IsValid)
                {
                    reponse = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Delete(id);
                    _postCategoryService.Save();

                    reponse = request.CreateResponse(HttpStatusCode.OK);
                }
                return reponse;
            });
        }
    }
}

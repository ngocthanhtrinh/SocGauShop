using AutoMapper;
using SocGauShop.Model.Models;
using SocGauShop.Service;
using SocGauShop.Web.Infrastructure.Core;
using SocGauShop.Web.Infrastructure.Extensions;
using SocGauShop.Web.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SocGauShop.Web.Api
{
    [RoutePrefix("api/PostCategory")]
    public class PostCategoryController : ApiControllerBase
    {
        private IPostCategoryService _postCategoryService;

        public PostCategoryController(IPostCategoryService postCategoryService, IErrorService errorService) : base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }
        [HttpGet]
        [Route("GetAll")]
        [ResponseType(typeof(IEnumerable<PostCategoryViewModel>))]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (ModelState.IsValid)
                {
                    var listPostCategory = _postCategoryService.GetAll();
                    var listPostCategoryVM = Mapper.Map<List<PostCategoryViewModel>>(listPostCategory);
                    response = request.CreateResponse(HttpStatusCode.OK, listPostCategoryVM);
                }
                else
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return response;
            });
        }
        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage Create(HttpRequestMessage request, PostCategoryViewModel postCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    PostCategory postCategory = new PostCategory();
                    postCategory.UpdatePostCategory(postCategoryVm);
                    var result = _postCategoryService.Add(postCategory);
                    _postCategoryService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return response;
            });
        }
        [HttpPut]
        [Route("Update")]
        public HttpResponseMessage Update(HttpRequestMessage request, PostCategoryViewModel postCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    var postCategoryDb = _postCategoryService.GetById(postCategoryVm.ID);
                    postCategoryDb.UpdatePostCategory(postCategoryVm);
                    _postCategoryService.Update(postCategoryDb);
                    _postCategoryService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK, ModelState);
                }
                else
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return response;
            });
        }
        [HttpDelete]
        [Route("Delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {

                    var result = _postCategoryService.Delete(id);
                    _postCategoryService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return response;
            });
        }
    }
}
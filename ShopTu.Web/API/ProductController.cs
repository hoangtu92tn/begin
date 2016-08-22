using ShopTu.Model.Models;
using ShopTu.Service;
using ShopTu.Web.Infrustructere.Core;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace ShopTu.Web.API
{
    //[RoutePrefix("api/product")]
    public class ProductController : ApiControllerBase
    {
        private IProductService _productService;

        public ProductController(IErrorService errorService, IProductService productService) : base(errorService)
        {
            this._productService = productService;
        }

        public HttpResponseMessage Get(HttpRequestMessage request,string keywork, int page, int pagesize)
        {
            return createHttpResponse(request, () =>
            {
                int totalRow = 0;
                var listProduct = _productService.GetAll(keywork);
                totalRow = listProduct.Count();
                var responseData = listProduct.Skip(page * pagesize).Take(pagesize);
                var pagination = new Pagination<Product>()
                {
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pagesize),
                    items = responseData,
                };
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, pagination);
                return response;
            });
        }

        //[Route("Create")]
        public HttpResponseMessage Post(HttpRequestMessage requestMessage, Product product)
        {
            return createHttpResponse(requestMessage, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    requestMessage.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    product = new Product()
                    {
                        ID = 1,
                        Name = "Tesst",
                        Alias = "121212",
                        CategoryID = 1,
                        Price = 121212,
                        Status = true
                    };
                    var productnew = _productService.Add(product);
                    _productService.Commit();

                    response = requestMessage.CreateResponse(HttpStatusCode.Created, productnew);
                }
                return response;
            });
        }
    }
}
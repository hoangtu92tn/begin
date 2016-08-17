using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopTu.Model.Models;
using ShopTu.Service;
using ShopTu.Web.Infrustructere.Core;

namespace ShopTu.Web.API
{
    //[RoutePrefix("api/product")]
    public class TestController : ApiControllerBase
    {
        private IProductService _productService;
        public TestController(IErrorService errorService, IProductService productService) : base(errorService)
        {
            this._productService = productService;
        }


        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return createHttpResponse(request, () =>
            {
                var listProduct = _productService.GetAll();
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listProduct);
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
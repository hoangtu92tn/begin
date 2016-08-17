using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using ShopTu.Model.Models;
using ShopTu.Service;
using ShopTu.Web.Infrustructere.Extension;
using ShopTu.Web.Models;

namespace ShopTu.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        private ITagService _tagService;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public HomeController(IProductService productService, ITagService tagService)
        {
            this._productService = productService;
            this._tagService = tagService;
        }

        public JsonResult GetData()
        {
            var result = _productService.GetAll();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetTagAll()
        {
            var result = _tagService.GetAll();
            var data = Mapper.Map<List<TagViewModel>>(result);
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Post(HttpRequestMessage requestMessage, TagViewModel tagVm)
        {

           Tag tagnew=new Tag();
            tagnew.UpdateTag(tagVm);
            var productnew = _tagService.Add(tagnew);
            _tagService.Commit();

            return Json("01", "Thanh cong");
        }


    }
}
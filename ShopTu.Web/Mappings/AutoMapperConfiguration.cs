using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ShopTu.Model.Models;
using ShopTu.Web.Models;

namespace ShopTu.Web.Mapping
{
    public class AutoMapperConfiguration
    {
        public static void Configuration()
        {
            Mapper.CreateMap<Tag, TagViewModel>();
        }
    }
}
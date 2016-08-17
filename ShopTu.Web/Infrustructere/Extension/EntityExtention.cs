using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopTu.Model.Models;
using ShopTu.Web.Models;

namespace ShopTu.Web.Infrustructere.Extension
{
    public static class EntityExtention
    {
        public static void UpdateTag(this Tag tag, TagViewModel tagVm)
        {
            tag.ID = tagVm.ID;
            tag.Name = tagVm.Name;
            tag.Type = tagVm.Type;
        }
    }
}
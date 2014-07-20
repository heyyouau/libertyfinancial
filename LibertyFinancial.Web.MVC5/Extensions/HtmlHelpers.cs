using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibertyFinancial.Web.MVC5
{
    public static class HtmlHelpers
    {
        public static IHtmlString LinkToRemoveNestedForm(this HtmlHelper htmlHelper, string linkText, string container, string deleteElement) 
        {
            var js = string.Format("removeNestedForm(this,'{0}','{1}');return false;", container, deleteElement);
            TagBuilder tb = new TagBuilder("a");
            tb.Attributes.Add("href", "#");
            tb.Attributes.Add("onclick", js);
            tb.InnerHtml = linkText;
            var tag = tb.ToString(TagRenderMode.Normal);
            return MvcHtmlString.Create(tag);
        }
    }  
}

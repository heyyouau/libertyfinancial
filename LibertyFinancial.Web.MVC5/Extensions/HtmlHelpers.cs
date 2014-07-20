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
            //var js = string.Format("javascript:removeNestedForm(this,'{0}','{1}');return false;", container, deleteElement);
            //TagBuilder tb = new TagBuilder("a");
            //tb.Attributes.Add("href", "#");
            //tb.Attributes.Add("onclick", js);
            //tb.InnerHtml = linkText;
            //var tag = tb.ToString(TagRenderMode.Normal);
            return MvcHtmlString.Create(FormLink(linkText, container, deleteElement));
        }


        private static string FormLink(string linkText, string container, string deleteElement)
        {
            var js = string.Format("javascript:removeNestedForm(this,'{0}','{1}');return false;", container, deleteElement);
            TagBuilder tb = new TagBuilder("a");
            tb.Attributes.Add("href", "#");
            tb.Attributes.Add("onclick", js);
            tb.InnerHtml = linkText;
            return tb.ToString(TagRenderMode.Normal);
        }

        public static IHtmlString AddModelNode(this HtmlHelper htmlHelper, string text, string prefix, string counter, string id, string type)
        {
            TagBuilder tb = new TagBuilder("div");
            tb.AddCssClass("row");
            tb.Attributes.Add("id", string.Format("{0}_{1}", prefix, id));

            TagBuilder textSpan = new TagBuilder("span");
            textSpan.AddCssClass(counter);
            textSpan.InnerHtml = text;
            
            tb.InnerHtml += textSpan.ToString();

            TagBuilder hidden = new TagBuilder("input");
            hidden.Attributes.Add("type", "hidden");
            hidden.Attributes.Add("id", string.Format("{0}_{1}_Delete", type, id));

            tb.InnerHtml += textSpan.ToString();
            tb.InnerHtml += FormLink("Remove", prefix + "_" + id, type + "_" + id + "_Delete");

            var tag = tb.ToString(TagRenderMode.Normal);
            return MvcHtmlString.Create(tag);
        }

        //public static IHtmlString LinkToAddNestedForm<TModel>(this HtmlHelper<TModel> htmlHelper, string linkText, string containerElement, string counterElement, string collectionProperty, Type nestedType)
        //{

        //    var ticks = DateTime.UtcNow.Ticks;
        //    var nestedObject = Activator.CreateInstance(nestedType);
        //    var partial = htmlHelper.EditorFor(x => nestedObject).ToHtmlString().JsEncode();
        //    partial = partial.Replace("id=\\\"nestedObject", "id=\\\"" + collectionProperty + "_" + ticks + "_");
        //    partial = partial.Replace("name=\\\"nestedObject", "name=\\\"" + collectionProperty + "[" + ticks + "]");
        //    var js = string.Format("javascript:addNestedForm('{0}','{1}','{2}','{3}');return false;", containerElement, counterElement, ticks, partial);
        //    TagBuilder tb = new TagBuilder("a");
        //    tb.Attributes.Add("href", "#");
        //    tb.Attributes.Add("onclick", js);
        //    tb.InnerHtml = linkText;
        //    var tag = tb.ToString(TagRenderMode.Normal);
        //    return MvcHtmlString.Create(tag);
        //}


    }  
}

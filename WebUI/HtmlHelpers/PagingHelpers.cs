using System;
using System.Text;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder resut = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-success");
                    tag.AddCssClass("mx-1");
                }
                tag.AddCssClass("btn btn-primary mx-1");
                resut.Append(tag.ToString());
            }
            return MvcHtmlString.Create(resut.ToString());
        }
    }
}
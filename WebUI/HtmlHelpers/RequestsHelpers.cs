using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using WebUI.ViewModels.Requests.View;

namespace WebUI.HtmlHelpers
{
    public static class RequestsHelpers
    {
        private const string SPACE = "&nbsp;";
        public static MvcHtmlString RequestCard(this HtmlHelper html, IEnumerable<RequestViewModel> requests, Func<int, string> requestUrl)
        {
            StringBuilder resut = new StringBuilder();
            TagBuilder divRoot = new TagBuilder("div");
            divRoot.AddCssClass("row");
            foreach (var request in requests)
            {
                TagBuilder divColumn = new TagBuilder("div");
                divColumn.AddCssClass("col-sm-12");
                divColumn.AddCssClass("col-md-6");
                divColumn.AddCssClass("col-lg-6");
                divColumn.AddCssClass("d-flex");

                TagBuilder divCard = new TagBuilder("div");
                divCard.AddCssClass("card");
                divCard.AddCssClass("text-black-50");
                divCard.AddCssClass("flex-fill");
                divCard.AddCssClass("mt-3");
                divCard.AddCssClass("mb-3");

                TagBuilder divCardBody = new TagBuilder("div");
                divCardBody.AddCssClass("card-body");

                TagBuilder divCardBodyRow = new TagBuilder("div");
                divCardBodyRow.AddCssClass("row");
                divCardBodyRow.AddCssClass("align-items-center");

                TagBuilder divColumnAction = new TagBuilder("div");
                divColumnAction.AddCssClass("col-8");

                TagBuilder headingSubtitle = new TagBuilder("h6");
                headingSubtitle.AddCssClass("card-subtitle");
                headingSubtitle.SetInnerText(request.ServiceModel.Name);

                divColumnAction.InnerHtml += headingSubtitle.ToString();
                divCardBodyRow.InnerHtml += divColumnAction.ToString();

                TagBuilder divColumnDate = new TagBuilder("div");
                divColumnDate.AddCssClass("col-4");

                TagBuilder paragraphDate = new TagBuilder("p");
                paragraphDate.AddCssClass("text-right");
                paragraphDate.AddCssClass("font-weight-light");
                paragraphDate.SetInnerText(request.Date.ToShortDateString());

                divColumnDate.InnerHtml += paragraphDate.ToString();
                divCardBodyRow.InnerHtml += divColumnDate.ToString();

                TagBuilder headingCardTitle = new TagBuilder("h4");
                headingCardTitle.AddCssClass("card-title");
                headingCardTitle.SetInnerText(request.Title + "  ");

                TagBuilder spanTitleBadge = new TagBuilder("span");
                spanTitleBadge.AddCssClass("statusBadge");
                spanTitleBadge.AddCssClass("badge");
                spanTitleBadge.AddCssClass("font-weight-normal");
                string statusBadge = GetCssClassBadges(request.StatusId);
                spanTitleBadge.AddCssClass(statusBadge);
                spanTitleBadge.SetInnerText(request.StatusModel.Shortname);

                headingCardTitle.InnerHtml += spanTitleBadge.ToString();

                TagBuilder paragraphCardText = new TagBuilder("p");
                paragraphCardText.AddCssClass("card-text");
                paragraphCardText.SetInnerText(request.Description);

                TagBuilder viewLink = new TagBuilder("a");
                string hrefView = GetHrefAttribute(html, request, "Details");
                viewLink.AddCssClass("card-link");
                viewLink.SetInnerText("Просмотр");
                viewLink.MergeAttribute("href", hrefView);

                TagBuilder printLink = new TagBuilder("a");
                string hrefPrint = GetHrefAttribute(html, request, "Print");
                printLink.AddCssClass("card-link");
                printLink.SetInnerText("Печать служебной записки");
                printLink.MergeAttribute("href", hrefPrint);

                TagBuilder clientInfo = new TagBuilder("i");
                clientInfo.AddCssClass("fas");
                clientInfo.AddCssClass("fa-user-tie");
                clientInfo.AddCssClass("d-flex");
                clientInfo.AddCssClass("justify-content-end");
                clientInfo.SetInnerText($"  {request.ClientModel.Fullname}");

                divCardBody.InnerHtml += divCardBodyRow.ToString();
                divCardBody.InnerHtml += headingCardTitle.ToString();
                divCardBody.InnerHtml += paragraphCardText.ToString();
                divCardBody.InnerHtml += viewLink.ToString();
                divCardBody.InnerHtml += printLink.ToString();
                divCardBody.InnerHtml += clientInfo.ToString();

                divCard.InnerHtml += divCardBody.ToString();
                divColumn.InnerHtml += divCard.ToString();
                divRoot.InnerHtml += divColumn.ToString();
            }
            resut.Append(divRoot.ToString());
            return MvcHtmlString.Create(resut.ToString());
        }

        private static string GetHrefAttribute(HtmlHelper html, RequestViewModel request, string action)
        {
            RouteValueDictionary routeValues = new RouteValueDictionary();
            routeValues.Add("controller", request.Source);
            routeValues.Add("action", action);
            routeValues.Add("id", request.RequestId);
            UrlHelper urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            return urlHelper.RouteUrl(routeValues);
        }

        private static string GetCssClassBadges(int statusId)
        {
            switch (statusId)
            {
                case 1: { return "badge-warning"; }
                case 2: { return "badge-info"; }
                case 3: { return "badge-success"; }
                case 4: { return "badge-pill"; }
                default: return null;
            }
        }

        private static string GetCssClassListGroup(int statusId)
        {
            switch (statusId)
            {
                case 1: { return "list-group-item-warning"; }
                case 2: { return "list-group-item-info"; }
                case 3: { return "list-group-item-success"; }
                case 4: { return "list-group-item-action"; }
                default: return null;
            }
        }
    }
}
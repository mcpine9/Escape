using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace EscapeMobility.WebUtilities.HtmlHelperExtensions
{
    public static class HtmlActionLinkHelpers
    {
        public static MvcHtmlString ImageActionRedirectLink(this HtmlHelper helper, string imgPath, string altText, string redirectUrl, object anchorAttributes)
        {
            var tbImg = new TagBuilder("img");
            tbImg.MergeAttribute("src", imgPath);
            tbImg.MergeAttribute("border", "0");
            tbImg.MergeAttribute("alt", altText);
            var tbAnchor = new TagBuilder("a");
            tbAnchor.MergeAttribute("href", "/Home/Redirect?url=" + redirectUrl);
            if (anchorAttributes != null)
            {
                tbAnchor.MergeAttributes(new RouteValueDictionary(anchorAttributes));
            }
            tbAnchor.InnerHtml = tbImg.ToString();
            return new MvcHtmlString(tbAnchor.ToString());
        }
        public static MvcHtmlString ImageActionRedirectLink(this HtmlHelper helper, string imgPath, string altText, UrlHelper page, ActionResult action, object anchorAttributes)
        {
            var tbImg = new TagBuilder("img");
            tbImg.MergeAttribute("src", imgPath);
            tbImg.MergeAttribute("border", "0");
            tbImg.MergeAttribute("alt", altText);
            var tbAnchor = new TagBuilder("a");
            tbAnchor.MergeAttribute("href", page.Action(action));
            if (anchorAttributes != null)
            {
                tbAnchor.MergeAttributes(new RouteValueDictionary(anchorAttributes));
            }
            tbAnchor.InnerHtml = tbImg.ToString();
            return new MvcHtmlString(tbAnchor.ToString());
        }
        public static MvcHtmlString ActionRedirectLink(this HtmlHelper helper, string innerText, string redirectUrl, object anchorAttributes)
        {
            var tbAnchor = new TagBuilder("a");
            tbAnchor.MergeAttribute("href", "/Home/Redirect?url=" + redirectUrl);
            tbAnchor.InnerHtml = innerText;
            if (anchorAttributes != null)
            {
                tbAnchor.MergeAttributes(new RouteValueDictionary(anchorAttributes));
            }
            return new MvcHtmlString(tbAnchor.ToString());
        }
    }
}
﻿using System.Web.Script.Serialization;

namespace System.Web.Mvc.Html {
    public static class HtmlExtensions {
        public static MvcHtmlString ToJson<T>(this HtmlHelper<T> helper, T entity) {
            return new MvcHtmlString(new JavaScriptSerializer().Serialize(entity));
        }
    }
}
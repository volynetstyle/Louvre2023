using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Newtonsoft.Json;

namespace Museum.App.Behaviors
{
    internal static class DefaultBehavior
    {
        internal static readonly Action<CookieApplyRedirectContext> ApplyRedirect =
            context =>
            {
                if (IsAjaxRequest(context.Request))
                {
                    string jsonResponse = JsonConvert.SerializeObject(
                        new
                        {
                            status = context.Response.StatusCode,
                            headers = 
                            new 
                            { 
                                location = context.RedirectUri 
                            }
                        },
                        Formatting.None);

                    context.Response.StatusCode = 200;
                    context.Response.Headers.Append("X-Responded-JSON", jsonResponse);
                }
                else
                {
                    context.Response.Redirect(context.RedirectUri);
                }
            };

        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.Headers != null)
                return request.Headers["X-Requested-With"] == "XMLHttpRequest";

            return false;
        }

        public static bool IsAjaxRequest(IOwinRequest request)
        {
            IReadableStringCollection query = request.Query;
            if (query != null)
            {
                if (query["X-Requested-With"] == "XMLHttpRequest")
                {
                    return true;
                }
            }

            Microsoft.Owin.IHeaderDictionary headers = request.Headers;
            if (headers != null)
            {
                if (headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
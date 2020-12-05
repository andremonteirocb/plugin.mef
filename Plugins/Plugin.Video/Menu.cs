using Plugin.SalaAula.Video.Areas.Video;
using Plugins.Infra.Contracts;
using System;
using System.ComponentModel.Composition;
using System.Web;
using System.Web.Mvc;

namespace Plugin.Video
{
    [Export(typeof(IMenu))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class Menu : IMenu
    {
        public string GroupName { get { return "Grupo Menu"; } }

        public bool CanShow()
        {
            return true;
        }

        public string LinkRelativeUrl
        {
            get
            {
                UrlHelper urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
                return urlHelper.RouteUrl(VideoAreaRegistration.ROUTE_NAME, new { controller = "Video", action = "Index" });
            }
        }
        public string IconRelativeUrl
        {
            get { return "fa fa-youtube-play"; }
        }
        public string Text
        {
            get { return "Vídeo"; }
        }
        public string Description
        {
            get { return "Vídeo"; }
        }
        public int Ordem
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Target => string.Empty;

        public bool isAtivo(HttpRequestBase request, string parameters = null)
        {
            string url = VirtualPathUtility.ToAbsolute(this.createLinkRelativeUrl(parameters));
            return url.Equals(request.Url.AbsolutePath, StringComparison.CurrentCultureIgnoreCase);
        }
        public string createLinkRelativeUrl(string parameters = null)
        {
            string result = this.LinkRelativeUrl;
            return result;
        }
    }
}
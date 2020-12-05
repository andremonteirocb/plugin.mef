using System.Web.Mvc;

namespace Plugin.SalaAula.Video.Areas.Video
{
    public class VideoAreaRegistration : AreaRegistration 
    {
        public const string ROUTE_NAME = "Video_default";

        public override string AreaName 
        {
            get 
            {
                return "Video";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
               ROUTE_NAME,
               "Video",
               new { Controller = "Video", action = "Index", id = UrlParameter.Optional }
           );
        }
    }
}
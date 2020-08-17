using System.Web.Mvc;

namespace Apartmani.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "VisitorGroups_Index",
                url: "turisti/{action}/{id}",
                defaults: new { controller = "VisitorGroups", action = "Status", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Status", controller = "VisitorGroups", id = UrlParameter.Optional }
            );
        }
    }
}
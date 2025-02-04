﻿using System.Web.Mvc;

namespace ElectronicStore.Areas.Admin
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
                "Admin",
                "Admin/{controller}/{action}/{id}",
                new { controller="DashBoard",action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ElectronicStore.Areas.Admin.Controllers" }

            );
        }
    }
}
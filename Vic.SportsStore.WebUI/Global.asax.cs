﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Vic.SportsStore.WebApp.Vic.SportsStore.WebApp;
using Vic.SportsStore.WebApp.Infrastructure.Binders;
using Vic.SportsStore.Domain.Entities;

namespace Vic.SportsStore.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
            AutofacConfig.Register();
        }
    }
}

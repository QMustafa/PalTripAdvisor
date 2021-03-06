﻿using SwaggerWcf;
using SwaggerWcf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace PalTripAdvisor.App_Start
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            SwaggerWcfEndpoint.FilterVisibleTags = FilterVisibleTags;
            SwaggerWcfEndpoint.FilterHiddenTags = FilterHiddenTags;
            SwaggerWcfEndpoint.DisableSwaggerUI = false;

            RouteTable.Routes.Add(new ServiceRoute("v1/rest", new WebServiceHostFactory(), typeof(GetClosestHotels)));
            RouteTable.Routes.Add(new ServiceRoute("v2/rest", new WebServiceHostFactory(), typeof(PointsOfInterest)));
            RouteTable.Routes.Add(new ServiceRoute("api-docs", new WebServiceHostFactory(), typeof(SwaggerWcfEndpoint)));

        }

        private static List<string> FilterVisibleTags(string path, List<string> visibleTags)
        {
            return visibleTags;
        }

        private static List<string> FilterHiddenTags(string path, List<string> hiddenTags)
        {
            return hiddenTags;
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
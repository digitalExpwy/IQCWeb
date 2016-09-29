using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;

[assembly: OwinStartup(typeof(IQCWeb.WebClient.Startup))]

namespace IQCWeb.WebClient
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }

    }
}
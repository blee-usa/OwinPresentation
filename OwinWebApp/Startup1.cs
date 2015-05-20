using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Diagnostics;
using Owin;

[assembly: OwinStartup("ProductionStartup", typeof(OwinWebApp.Startup1))]

namespace OwinWebApp
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // Add the error page middleware to the pipeline. (Microsoft.Owin.Diagnostics)


            app.Properties["host.AppMode"] = "prod";
            app.UseErrorPage(new ErrorPageOptions());

            


            app.Run(context =>
            {

                if (context.Request.Path.Value == "/fail")
                {
                    throw new Exception("Random exception");
                }

                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Hello, world. (production startup)");
            });
        }
    }
}

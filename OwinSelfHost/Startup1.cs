using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OwinSelfHost.Startup1))]

namespace OwinSelfHost
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            app.Run(context =>
            {
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Hello, world.. look mom, no IIS");
            });
        }
    }
}

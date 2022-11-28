using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Google;
using Owin;

[assembly: OwinStartup(typeof(Dostava_projekat.App_Start.Startup))]

namespace Dostava_projekat.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "970100597235-ocvt7d4d6ltkrcboc5lvjjjk9jbdh5ho.apps.googleusercontent.com",
                ClientSecret = "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"
            }

                );


        }
    }
}

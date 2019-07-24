using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using IdenetityAPI.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using Microsoft.Owin.Cors;
[assembly: OwinStartup(typeof(IdenetityAPI.Startup1))]

namespace IdenetityAPI
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath =new PathString("/token"),
                AllowInsecureHttp = true,
                AccessTokenExpireTimeSpan =TimeSpan.FromDays(3),
                Provider = new MyProvider()
            });

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }

    internal class MyProvider : OAuthAuthorizationServerProvider
    {
        //validate client
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        //loin (username,password)
        //token
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (context.UserName == null || context.Password == null)
            {
                context.SetError("name or password required");
            }
            else
            { 
               //call find function from authentication bussiness layer
                AuthBl auth = new AuthBl();
                IdentityUser user = auth.find(context.UserName, context.Password);
                //not find
                if (user == null)
                {
                    context.SetError("name or password required");
                }
                //finded
                else
                {
                    //create token
                    ClaimsIdentity claims = new ClaimsIdentity(context.Options.AuthenticationType);
                    claims.AddClaim(new Claim("Name", user.UserName));
                    claims.AddClaim(new Claim("Email", user.Email));
                    claims.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
                    // claims.AddClaim(new Claim("Role", "Admin"));
                    context.Validated(claims);
                }
            }
        }
    }
}

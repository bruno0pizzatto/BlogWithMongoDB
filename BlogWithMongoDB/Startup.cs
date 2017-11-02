using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogWithMongoDB.Startup))]
namespace BlogWithMongoDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}

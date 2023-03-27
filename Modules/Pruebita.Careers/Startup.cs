using Fluid;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Handlers;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.Data.Migration;
using Pruebita.Careers.Drivers;
using Pruebita.Careers.Handlers;
using Pruebita.Careers.Models;
using Pruebita.Careers.Settings;
using Pruebita.Careers.ViewModels;
using OrchardCore.Modules;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Pruebita.Careers
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.Configure<TemplateOptions>(o =>
            {
                o.MemberAccessStrategy.Register<CareersPartViewModel>();
            });

            services.AddContentPart<CareersPart>()
                .UseDisplayDriver<CareersPartDisplayDriver>()
                .AddHandler<CareersPartHandler>();

            services.AddScoped<IContentTypePartDefinitionDisplayDriver, CareersPartSettingsDisplayDriver>();
            services.AddDataMigration<Migrations>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                name: "Home",
                areaName: "Pruebita.Careers",
                pattern: "Home/Index",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}

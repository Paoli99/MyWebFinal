using OrchardCore.ContentManagement.Handlers;
using System.Threading.Tasks;
using Pruebita.Careers.Models;

namespace Pruebita.Careers.Handlers
{
    public class CareersPartHandler : ContentPartHandler<CareersPart>
    {
        public override Task InitializingAsync(InitializingContentContext context, CareersPart part)
        {
            part.Show = true;

            return Task.CompletedTask;
        }
    }
}
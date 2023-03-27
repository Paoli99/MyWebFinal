using System.Threading.Tasks;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using Pruebita.Careers.Models;
using Pruebita.Careers.Settings;
using Pruebita.Careers.ViewModels;

namespace Pruebita.Careers.Drivers
{
    public class CareersPartDisplayDriver : ContentPartDisplayDriver<CareersPart>
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public CareersPartDisplayDriver(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public override IDisplayResult Display(CareersPart part, BuildPartDisplayContext context)
        {
            return Initialize<CareersPartViewModel>(GetDisplayShapeType(context), m => BuildViewModel(m, part, context))
                .Location("Detail", "Content:10")
                .Location("Summary", "Content:10")
                ;
        }

        public override IDisplayResult Edit(CareersPart part, BuildPartEditorContext context)
        {
            return Initialize<CareersPartViewModel>(GetEditorShapeType(context), model =>
            {
                model.Show = part.Show;
                model.ContentItem = part.ContentItem;
                model.CareersPart = part;
            });
        }

        public override async Task<IDisplayResult> UpdateAsync(CareersPart model, IUpdateModel updater)
        {
            await updater.TryUpdateModelAsync(model, Prefix, t => t.Show);

            return Edit(model);
        }

        private Task BuildViewModel(CareersPartViewModel model, CareersPart part, BuildPartDisplayContext context)
        {
            var settings = context.TypePartDefinition.GetSettings<CareersPartSettings>();

            model.ContentItem = part.ContentItem;
            model.MySetting = settings.MySetting;
            model.Show = part.Show;
            model.CareersPart = part;
            model.Settings = settings;

            return Task.CompletedTask;
        }
    }
}

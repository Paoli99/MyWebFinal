using System;
using System.Threading.Tasks;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using Pruebita.Careers.Models;

namespace Pruebita.Careers.Settings
{
    public class CareersPartSettingsDisplayDriver : ContentTypePartDefinitionDisplayDriver
    {
        public override IDisplayResult Edit(ContentTypePartDefinition contentTypePartDefinition, IUpdateModel updater)
        {
            if (!String.Equals(nameof(CareersPart), contentTypePartDefinition.PartDefinition.Name))
            {
                return null;
            }

            return Initialize<CareersPartSettingsViewModel>("CareersPartSettings_Edit", model =>
            {
                var settings = contentTypePartDefinition.GetSettings<CareersPartSettings>();

                model.MySetting = settings.MySetting;
                model.CareersPartSettings = settings;
            }).Location("Content");
        }

        public override async Task<IDisplayResult> UpdateAsync(ContentTypePartDefinition contentTypePartDefinition, UpdateTypePartEditorContext context)
        {
            if (!String.Equals(nameof(CareersPart), contentTypePartDefinition.PartDefinition.Name))
            {
                return null;
            }

            var model = new CareersPartSettingsViewModel();

            if (await context.Updater.TryUpdateModelAsync(model, Prefix, m => m.MySetting))
            {
                context.Builder.WithSettings(new CareersPartSettings { MySetting = model.MySetting });
            }

            return Edit(contentTypePartDefinition, context.Updater);
        }
    }
}

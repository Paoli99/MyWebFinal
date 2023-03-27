using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Pruebita.Careers.Settings
{
    public class CareersPartSettingsViewModel
    {
        public string MySetting { get; set; }

        [BindNever]
        public CareersPartSettings CareersPartSettings { get; set; }
    }
}

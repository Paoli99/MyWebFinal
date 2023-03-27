using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.ContentManagement;
using Pruebita.Careers.Models;
using Pruebita.Careers.Settings;

namespace Pruebita.Careers.ViewModels
{
    public class CareersPartViewModel
    {
        public string MySetting { get; set; }

        public bool Show { get; set; }

        [BindNever]
        public ContentItem ContentItem { get; set; }

        [BindNever]
        public CareersPart CareersPart { get; set; }

        [BindNever]
        public CareersPartSettings Settings { get; set; }
    }
}

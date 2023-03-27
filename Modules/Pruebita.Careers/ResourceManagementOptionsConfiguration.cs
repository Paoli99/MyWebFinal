using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;
 
namespace Truextend.Careers;

public class ResourceManagementOptionsConfiguration : IConfigureOptions<ResourceManagementOptions>
{
    private static readonly ResourceManifest _manifest = new();
    static ResourceManagementOptionsConfiguration() {
        _manifest
        .DefineStyle("Styles")
        .SetUrl("..\\Pruebita.Web\\Css\\StyleSheet.css");
    }
    public void Configure(ResourceManagementOptions options) => options.ResourceManifests.Add(_manifest);
}

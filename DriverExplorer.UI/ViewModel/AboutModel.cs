using Neutronium.BuildingBlocks.Application.ViewModels;

namespace DriverExplorer.UI.ViewModel
{
    public class AboutViewModel
    {
        public ApplicationInformation Information { get; } = new ApplicationInformation("Neutronium Demo", "David Desmaisons");

        public string[] Descriptions { get; } =
        {
            Resource.About1,
            Resource.About2,
            Resource.About3
        };
    }
}

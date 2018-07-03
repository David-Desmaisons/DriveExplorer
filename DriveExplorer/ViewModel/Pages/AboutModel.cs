namespace DriveExplorer.ViewModel.Pages
{
    public class AboutViewModel
    {
        public ApplicationInformation Information { get; } = new ApplicationInformation();

        public string[] Descriptions { get; } =
        {
            Resource.About
        };
    }
}

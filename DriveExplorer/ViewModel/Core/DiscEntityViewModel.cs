namespace DriveExplorer.ViewModel.Core
{
    public class DiscEntityViewModel
    {
        public string Name { get; set;  }
        public bool IsAcessible { get; set; }
        public DiscEntityViewModel[] Children { get; set;  }
        public SizeViewModel Size { get; set; }

        public DiscEntityViewModel()
        {
        }
    }
}

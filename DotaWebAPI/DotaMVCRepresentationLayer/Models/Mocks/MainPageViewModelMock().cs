using DotaMVCRepresentationLayer.Models.Interfaces;

namespace DotaMVCRepresentationLayer.Models.Mocks
{
    public class MainPageViewModelMock : IMainPageViewModel
    {
        public MainPageViewModelMock()
        {
            SiteTitle = "Main page";
        }
        public string SiteTitle { get; set; }
    }
}
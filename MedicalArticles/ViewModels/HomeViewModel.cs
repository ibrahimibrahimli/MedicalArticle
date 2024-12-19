using Entities.Dtos;
using Entities.TableModels;

namespace MedicalArticles.ViewModels
{
    public class HomeViewModel
    {
        public List<Slide> Slides { get; set; }
        public List<ServiceAboutDto> ServiceAbout { get; set; }
        public List<Service> Services { get; set; }
        public List<HealtTipDto> HealtTip{ get; set; }
        public List<TeamBoard> Teamboard { get; set; }
        public List<Fact> Facts { get; set; }
        public List<BlogDto> Blogs { get; set; }
    }
}

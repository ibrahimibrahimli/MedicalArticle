using Entities.Dtos;
using Entities.TableModels;

namespace MedicalArticles.ViewModels
{
    public class HomeViewModel
    {
        public List<Slide> Slides { get; set; }
        public List<ServiceAboutItemsDto> ServiceAboutItems { get; set; }
        public List<ServiceDto> Services { get; set; }
        public List<HealtTipItemsDto> HealtTipItems { get; set; }
        public List<TeamBoard> Teamboard { get; set; }
    }
}

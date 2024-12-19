using Entities.Dtos;
using Entities.TableModels;

namespace MedicalArticles.ViewModels
{
    public class AboutViewModel
    {
        public List<Service> Services { get; set; }
        public List<WhyChooseUsDto> WhyChooseUS { get; set; }
        public List<TeamBoard> Teamboards { get; set; }
    }
}

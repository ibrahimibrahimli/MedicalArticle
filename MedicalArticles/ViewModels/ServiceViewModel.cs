using Entities.Dtos;
using Entities.TableModels;

namespace MedicalArticles.ViewModels
{
    public class ServiceViewModel
    {
        public List<Faq> Faqs { get; set; }
        public List<Service> Services { get; set; }
        public List<WhyChooseUsDto> WhyChoseUs { get; set; }
    }
}

using Entities.TableModels;

namespace Entities.Dtos
{
    public class WhyChooseUsItemsDto
    {
        public int Id { get; set; }
        public int WhyChooseUsId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string WhyUsDescription { get; set; }
        public string WhyUsPhotoUrl { get; set; }
        public virtual WhyChooseUs WhyChooseUs { get; set; }
    }
}

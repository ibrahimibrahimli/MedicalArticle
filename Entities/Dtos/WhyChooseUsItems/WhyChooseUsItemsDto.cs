using Entities.TableModels;

namespace Entities.Dtos
{
    public class WhyChooseUsItemsDto
    {
        public int Id { get; set; }
        public int WhyChooseUsId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual WhyChooseUs WhyChooseUs { get; set; }
    }
}

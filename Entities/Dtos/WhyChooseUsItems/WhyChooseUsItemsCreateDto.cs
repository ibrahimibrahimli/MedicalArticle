using Entities.TableModels;

namespace Entities.Dtos
{
    public class WhyChooseUsItemsCreateDto
    {
        public int WhyChooseUsId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public static WhyChooseUsItems ToWhyChooseUsItems(WhyChooseUsItemsCreateDto dto)
        {
            WhyChooseUsItems whyChooseUsItems = new WhyChooseUsItems()
            {
                WhyChooseUsId = dto.WhyChooseUsId,
                Title = dto.Title,
                Description = dto.Description
            };
            return whyChooseUsItems;
        }
    }
}

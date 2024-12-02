using Entities.TableModels;

namespace Entities.Dtos
{
    public class WhyChooseUsItemsUpdateDto
    {
        public int Id { get; set; }
        public int WhyChooseUsId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public static WhyChooseUsItems ToWhyChooseUsItems(WhyChooseUsItemsUpdateDto dto)
        {
            WhyChooseUsItems whyChooseUsItems = new WhyChooseUsItems()
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                WhyChooseUsId = dto.WhyChooseUsId
            };
            return whyChooseUsItems;
        }
    }
}

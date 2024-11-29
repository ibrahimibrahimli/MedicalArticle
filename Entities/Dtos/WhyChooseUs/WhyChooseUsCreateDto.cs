using Entities.TableModels;

namespace Entities.Dtos
{
    public class WhyChooseUsCreateDto
    {
        public string Description { get; set; }
        public string PhotoUrl { get; set; }

        public static WhyChooseUs ToWhyChooseUs(WhyChooseUsCreateDto dto)
        {
            WhyChooseUs whyChooseUs = new WhyChooseUs()
            {
                Description = dto.Description,
                PhotoUrl = dto.PhotoUrl,
            };
            return whyChooseUs;
        }
    }
}

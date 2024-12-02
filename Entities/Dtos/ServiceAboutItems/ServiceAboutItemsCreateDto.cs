using Entities.TableModels;

namespace Entities.Dtos
{
    public class ServiceAboutItemsCreateDto
    {
        public int ServiceAboutId { get; set; }
        public string Text { get; set; }

        public static ServiceAboutItemDto ToServiceAboutItems(ServiceAboutItemsCreateDto dto)
        {
            ServiceAboutItemDto serviceAboutItems = new ServiceAboutItemDto()
            {
                Text = dto.Text,
                ServiceAboutId = dto.ServiceAboutId
            };
            return serviceAboutItems;
        }
    }
}

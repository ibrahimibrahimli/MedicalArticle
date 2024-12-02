using Entities.TableModels;

namespace Entities.Dtos
{
    public class ServiceAboutItemsUpdateDto
    {
        public int Id { get; set; }
        public int ServiceAboutId { get; set; }
        public string Text { get; set; }

        public static ServiceAboutItemDto ToServiceAboutItems(ServiceAboutItemsUpdateDto dto)
        {
            ServiceAboutItemDto serviceAboutItems = new ServiceAboutItemDto()
            {
                Id = dto.Id,
                Text = dto.Text,
                ServiceAboutId = dto.ServiceAboutId
            };
            return serviceAboutItems;
        }
    }
}

using Entities.TableModels;

namespace Entities.Dtos
{
    public class ServiceAboutItemsUpdateDto
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public static ServiceAboutItems ToServiceAboutItems(ServiceAboutItemsUpdateDto dto)
        {
            ServiceAboutItems serviceAboutItems = new ServiceAboutItems()
            {
                Id = dto.Id,
                Text = dto.Text,
            };
            return serviceAboutItems;
        }
    }
}

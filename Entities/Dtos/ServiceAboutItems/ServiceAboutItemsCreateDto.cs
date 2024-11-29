using Entities.TableModels;

namespace Entities.Dtos
{
    public class ServiceAboutItemsCreateDto
    {
        public string Text { get; set; }

        public static ServiceAboutItems ToServiceAboutItems(ServiceAboutItemsCreateDto dto)
        {
            ServiceAboutItems serviceAboutItems = new ServiceAboutItems()
            {
                Text = dto.Text,
            };
            return serviceAboutItems;
        }
    }
}

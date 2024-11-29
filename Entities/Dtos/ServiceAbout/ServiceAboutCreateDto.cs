using Entities.TableModels;

namespace Entities.Dtos
{
    public class ServiceAboutCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }

        public static ServiceAbout ToServiceAbout(ServiceAboutCreateDto dto)
        {
            ServiceAbout serviceAbout = new ServiceAbout()
            {
                Title = dto.Title,
                Description = dto.Description,
                PhotoUrl = dto.PhotoUrl,
            };
            return serviceAbout;
        }
    }
}

using Entities.TableModels;

namespace Entities.Dtos
{
    public class ServiceAboutUpdateDto
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }

        public static ServiceAbout ToServiceAbout(ServiceAboutUpdateDto dto)
        {
            ServiceAbout serviceAbout = new ServiceAbout()
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                PhotoUrl = dto.PhotoUrl,
            };
            return serviceAbout;
        }
    }
}

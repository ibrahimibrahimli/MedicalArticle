using Entities.TableModels;

namespace Entities.Dtos
{
    public class ServiceAboutDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<ServiceAboutItemDto> ServiceAboutItems { get; set; }
    }
}

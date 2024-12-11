using Entities.TableModels;

namespace Entities.Dtos
{
    public class FactUpdateDto
    {
        public int Id { get; set; }
        public string IconUrl { get; set; }
        public string Title { get; set; }
        public int Counter { get; set; }

        public static Fact ToFact(FactUpdateDto dto)
        {
            return new Fact
            {
                Id = dto.Id,
                IconUrl = dto.IconUrl,
                Title = dto.Title,
                Counter = dto.Counter
            };
        }
    }
}
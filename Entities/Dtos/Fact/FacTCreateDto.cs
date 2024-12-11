using Entities.TableModels;

namespace Entities.Dtos
{
    public class FacTCreateDto
    {
        public string IconUrl { get; set; }
        public string Title { get; set; }
        public int Counter { get; set; }

        public static Fact toFact(FacTCreateDto dto)
        {
            return new Fact
            {
                IconUrl = dto.IconUrl,
                Title = dto.Title,
                Counter = dto.Counter
            };
        }
    }
}

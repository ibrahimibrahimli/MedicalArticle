using Entities.TableModels;

namespace Entities.Dtos
{
    public class WriterUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public static Writer ToWriter(WriterUpdateDto dto)
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
            };
        }
    }
}

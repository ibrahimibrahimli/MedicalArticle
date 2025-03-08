using Entities.TableModels;

namespace Entities.Dtos
{
    public class WriterCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public static Writer ToWriter(WriterCreateDto dto)
        {
            return new()
            {
                Name = dto.Name,
                Surname = dto.Surname,
            };
        }
    }
}

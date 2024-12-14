using Entities.TableModels;

namespace Entities.Dtos
{
    public class HealtTipUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Header { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SubTitle { get; set; }
        public string PhotoUrl { get; set; }
        public int LanguageId { get; set; }

        public static HealtTip ToHealtTip(HealtTipUpdateDto dto)
        {
            HealtTip healtTip = new HealtTip()
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
                Header = dto.Header,
                Title = dto.Title,
                Description = dto.Description,
                SubTitle = dto.SubTitle,
                PhotoUrl = dto.PhotoUrl,
                LanguageId = dto.LanguageId,
            };
            return healtTip;
        }
    }
}

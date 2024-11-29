using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class HealtTipCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Header { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SubTitle { get; set; }
        public string PhotoUrl { get; set; }

        public static HealtTip ToHealtTip(HealtTipCreateDto dto)
        {
            HealtTip healtTip = new HealtTip()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Header = dto.Header,
                Title = dto.Title,
                Description = dto.Description,
                SubTitle = dto.SubTitle,
                PhotoUrl = dto.PhotoUrl,
            };
            return healtTip;
        }
    }
}

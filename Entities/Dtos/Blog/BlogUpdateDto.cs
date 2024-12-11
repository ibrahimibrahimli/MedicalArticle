using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class BlogUpdateDto
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsHomePage { get; set; }
        public int TeamboardId { get; set; }

        public static Blog ToBlog(BlogUpdateDto dto)
        {
            return new Blog
            {
                Id = dto.Id,
                Title = dto.Title,
                Text = dto.Text,
                TeamboardId = dto.TeamboardId,
                PhotoUrl = dto.PhotoUrl,
                IsHomePage = dto.IsHomePage,
            };
        }
    }
}

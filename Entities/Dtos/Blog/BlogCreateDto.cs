﻿using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class BlogCreateDto
    {
        public string PhotoUrl { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int TeamboardId { get; set; }

        public static Blog ToBlog(BlogCreateDto dto)
        {
            return new Blog
            {
                PhotoUrl = dto.PhotoUrl,
                Title = dto.Title,
                Text = dto.Text,
                TeamboardId = dto.TeamboardId,
            };
        }
    }
}
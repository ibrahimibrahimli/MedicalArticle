﻿using Entities.Dtos;
using Entities.TableModels;

namespace MedicalArticles.ViewModels
{
    public class BlogDetailsViewModel
    {
        public BlogDto Blog { get; set; }
        public List<Sosial> Sosials { get; set; }
        public List<BlogDto> Blogs { get; set; }
        public List<Comment> Comments { get; set; }
        public CommentCreateDto Comment { get; set; }
    }
}

using Entities.TableModels;

namespace Entities.Dtos
{
    public class CommentCreateDto
    {
        public int BlogId { get; set; }
        public int? ParentCommentId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public required string Content { get; set; }

        public static Comment ToComment(CommentCreateDto commentCreateDto)
        {
            return new Comment
            {
                BlogId = commentCreateDto.BlogId,
                ParentCommentId = commentCreateDto.ParentCommentId,
                UserName = commentCreateDto.UserName,
                UserSurname = commentCreateDto.UserSurname,
                Content = commentCreateDto.Content
            };
        }
    }
}

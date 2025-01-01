using Entities.TableModels;

namespace Entities.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int? ParentCommentId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public required string Content { get; set; }
        public List<Comment> Replies { get; set; } = [];
        public DateTime CreatedDate { get; set; }

        public static Comment ToComment(CommentDto commentUpdateDto)
        {
            return new Comment
            {
                Id = commentUpdateDto.Id,
                BlogId = commentUpdateDto.BlogId,
                ParentCommentId = commentUpdateDto.ParentCommentId,
                UserName = commentUpdateDto.UserName,
                UserSurname = commentUpdateDto.UserSurname,
                Content = commentUpdateDto.Content,
                Replies = commentUpdateDto.Replies,
                CreatedDate = commentUpdateDto.CreatedDate
            };
        }
    }
}

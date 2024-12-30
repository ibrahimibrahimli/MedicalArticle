namespace Entities.TableModels
{
    public class Comment
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int? ParentCommentId { get; set; }
        public int UserName { get; set; }
        public int UserSurname { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; } 

        // Navigation properties
        public Blog Blog { get; set; }
        public List<Comment> Replies { get; set; } = new List<Comment>();
    }

}

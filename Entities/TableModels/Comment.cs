using Core.Entities.Abstract;

namespace Entities.TableModels
{
    public class Comment : BaseEntity
    {
        public int BlogId { get; set; }
        public int? ParentCommentId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public  string Content { get; set; }
        public List<Comment> Replies { get; set; } = [];

        // Navigation properties
        public Blog Blog { get; set; }
        public Comment ParentComment { get; set; }
    }

}

using Core.Entities.Abstract;

namespace Entities.TableModels
{
    public class Fact : BaseEntity
    {
        public string IconUrl { get; set; }
        public string Title { get; set; }
        public int Counter { get; set; }
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
    }
}

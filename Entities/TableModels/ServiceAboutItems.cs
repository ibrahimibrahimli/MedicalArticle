using Core.Entities.Abstract;

namespace Entities.TableModels
{
    public class ServiceAboutItems : BaseEntity
    {
        public int ServiceAboutId { get; set; }
        public string Text { get; set; }
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
        public virtual ServiceAbout ServiceAbout { get; set; }
    }
}

using Core.Entities.Abstract;

namespace Entities.TableModels
{
    public class Language : BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}

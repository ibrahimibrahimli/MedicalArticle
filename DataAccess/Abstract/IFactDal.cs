using Core.DataAccess.Abstract;
using Entities.TableModels;

namespace DataAccess.Abstract
{
    public interface IFactDal : IBaseRepository<Fact>
    {
        List<Fact> GetDataByLanguage(string lang);
    }
}

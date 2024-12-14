using Core.DataAccess.Abstract;
using Entities.Dtos;
using Entities.TableModels;

namespace DataAccess.Abstract
{
    public interface IHealtTipDal : IBaseRepository<HealtTip>
    {
        List<HealtTipDto> GetHealtTipsWithItems();
        List<HealtTip> GetDataByLanguage(string lang);
    }
}

using Core.DataAccess.Abstract;
using Entities.Dtos;
using Entities.TableModels;

namespace DataAccess.Abstract
{
    public interface IHealtTipItemsDal : IBaseRepository<HealtTipItems>
    {
        List<HealtTipItemsDto> GetHealtTipItemsWithHealtTip();
        List<HealtTipItems> GetDataByLanguage(string lang);
    }
}

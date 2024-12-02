using Core.DataAccess.Abstract;
using Entities.Dtos;
using Entities.TableModels;

namespace DataAccess.Abstract
{
    public interface IWhyChooseUsItemsDal : IBaseRepository<WhyChooseUsItems>
    {
        List<WhyChooseUsItemsDto> GetWhyUsItemsWidthWhyUs();
    }
}

using Core.DataAccess.Abstract;
using Entities.Dtos;
using Entities.TableModels;

namespace DataAccess.Abstract
{
    public interface IWhyChooseUsDal : IBaseRepository<WhyChooseUs>
    {
        List<WhyChooseUsDto> GetWhyUsWithItems(string lang);
    }
}

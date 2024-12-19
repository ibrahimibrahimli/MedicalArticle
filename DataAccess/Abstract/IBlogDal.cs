using Core.DataAccess.Abstract;
using Entities.Dtos;
using Entities.TableModels;

namespace DataAccess.Abstract
{
    public interface IBlogDal : IBaseRepository<Blog>
    {
        List<BlogDto> GetDataByLanguage(string lang);
    }
}

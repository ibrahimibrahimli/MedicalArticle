using Core.DataAccess.Abstract;
using Entities.TableModels;

namespace DataAccess.Abstract
{
    public interface ITeamBoardDal : IBaseRepository<TeamBoard>
    {
        List<TeamBoard> GetDataByLanguage(string lang);
    }
}

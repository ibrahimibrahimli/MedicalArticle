using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.SqlServerDBContext;
using Entities.TableModels;

namespace DataAccess.Concrete
{
    public class TeamBoardDal : BaseRepository<TeamBoard, ApplicationDbContext>, ITeamBoardDal
    {
    }
}

using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.SqlServerDBContext;
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class TeamBoardDal : BaseRepository<TeamBoard, ApplicationDbContext>, ITeamBoardDal
    {
        private readonly ApplicationDbContext? _context;

        public TeamBoardDal(ApplicationDbContext? context)
        {
            _context = context;
        }

        public List<TeamBoard> GetDataByLanguage(string lang)
        {
            var data = _context.TeamBoards
                .Include(d => d.Language)
                .Where(d => d.Language.Key == lang)
                .Where(d => d.Deleted == 0);

            return [.. data];
        }
    }
}

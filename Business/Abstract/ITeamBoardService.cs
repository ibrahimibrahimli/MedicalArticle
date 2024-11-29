using Core.Results.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ITeamBoardService
    {
        IResult Add(TeamBoardCreateDto dto, IFormFile photoUrl, string webRootPath);
        IResult Update(TeamBoardUpdateDto dto, IFormFile photoUrl, string webRootPath);
        IResult SoftDelete(int id);
        IResult HardDelete(int id);
        IDataResult<List<TeamBoard>> GetAll();
        IDataResult<List<TeamBoard>> GetAllDeleted();
        IDataResult<TeamBoard> GetById(int id);
    }
}

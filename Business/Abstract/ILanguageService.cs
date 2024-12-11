using Core.Results.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ILanguageService
    {
        IDataResult<List<Language>> GetAll();
        IDataResult<Language> GetById(int id);
    }
}

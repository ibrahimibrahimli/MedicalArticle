using Business.Abstract;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using Entities.TableModels;

namespace Business.Concrete
{
    public class LanguageManager : ILanguageService
    {
        private readonly ILanguageDal _languageDal;

        public LanguageManager(ILanguageDal languageDal)
        {
            _languageDal = languageDal;
        }

        public IDataResult<List<Language>> GetAll()
        {
            return new SuccessDataResult<List<Language>>(_languageDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Language> GetById(int id)
        {
            return new SuccessDataResult<Language>(_languageDal.GetById(id));
        }
    }
}

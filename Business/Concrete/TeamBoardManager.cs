using Business.Abstract;
using Business.BaseMessages;
using Core.Extension;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Dtos;
using Entities.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class TeamBoardManager : ITeamBoardService
    {
        private readonly ITeamBoardDal _teamBoardDal;
        private readonly IValidator<TeamBoard> _validator;

        public TeamBoardManager(ITeamBoardDal teamBoardDal, IValidator<TeamBoard> validator)
        {
            _teamBoardDal = teamBoardDal;
            _validator = validator;
        }

        public IResult Add(TeamBoardCreateDto dto, IFormFile photoUrl, string webRootPath)
        {
            TeamBoard model = TeamBoardCreateDto.ToTeamBoard(dto);
            var validator = _validator.Validate(model);
            model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);

            string errorMessage = "";

            foreach (var error in validator.Errors)
            {
                errorMessage = error.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }

            _teamBoardDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage(model.Name));
        }

        public IDataResult<List<TeamBoard>> GetAll()
        {
            return new SuccessDataResult<List<TeamBoard>>(_teamBoardDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<List<TeamBoard>> GetAllDeleted()
        {
            return new SuccessDataResult<List<TeamBoard>>(_teamBoardDal.GetAll(x => x.Deleted != 0));
        }

        public IDataResult<TeamBoard> GetById(int id)
        {
            return new SuccessDataResult<TeamBoard>(_teamBoardDal.GetById(id));
        }

        public IDataResult<List<TeamBoard>> GetDataByLanguage(string lang)
        {
            return new SuccessDataResult<List<TeamBoard>>(_teamBoardDal.GetDataByLanguage(lang));
        }

        public IResult HardDelete(int id)
        {
            var data = GetById(id).Data;
            _teamBoardDal.Delete(data);

            return new SuccessResult(UiMessages.SuccessDeletedMessage(data.Name));
        }

        public IResult ReturnDeleted(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = 0;
            _teamBoardDal.Update(data);

            return new SuccessResult(UiMessages.SuccessReturnTrashMessage(data.Name));
        }

        public IResult SoftDelete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _teamBoardDal.Update(data);

            return new SuccessResult(UiMessages.SuccessCopyTrashMessage(data.Name));
        }

        public IResult Update(TeamBoardUpdateDto dto, IFormFile photoUrl, string webRootPath)
        {
            TeamBoard model = TeamBoardUpdateDto.ToTeamBoard(dto);
            TeamBoard existData = GetById(model.Id).Data;

            if (photoUrl is null)
                model.PhotoUrl = existData.PhotoUrl;
            else
                model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);


            model.UpdatedDate = DateTime.Now;
            _teamBoardDal.Update(model);

            return new SuccessResult(UiMessages.SuccessUpdatedMessage(model.Name));
        }
    }
}

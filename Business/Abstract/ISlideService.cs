﻿using Core.Results.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ISlideService
    {
        IResult Add(SlideCreateDto dto, IFormFile photoUrl, string webRootPath);
        IResult Update(SlideUpdateDto dto, IFormFile photoUrl, string webRootPath);
        IDataResult<List<Slide>> GetAll(string lang);
        IDataResult<List<Slide>> GetAllDeleted();
        IDataResult<Slide> GetById(int id);
        IResult HardDelete(int id);
        IResult SoftDelete(int id);
        IResult ReturnDeleted(int id);
        IDataResult<List<Slide>> GetDataByLanguage(string lang);
    }
}

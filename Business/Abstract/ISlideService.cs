using Core.Results.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISlideService
    {
        IResult Add(SlideCreateDto dto, IFormFile photoUrl, string webRootPath);
        IResult Update(SlideUpdateDto dto, IFormFile photoUrl, string webRootPath);
        IDataResult<List<Slide>> GetAll();
        IDataResult<List<Slide>> GetAllDeleted();
        IDataResult<Slide> GetById(int id);
        IResult HardDelete(int id);
        IResult SoftDelete(int id);
    }
}

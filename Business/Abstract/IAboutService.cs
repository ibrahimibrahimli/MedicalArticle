﻿using Core.Results.Abstract;
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
    public interface IAboutService
    {
        IResult Add(AboutCreateDto dto, IFormFile photoUrl, string webRootPath);
        IResult Update (AboutUpdateDto dto, IFormFile photoUrl, string webRootPath);
        IResult SoftDelete(int  id);
        IResult HardDelete(int  id);
        IDataResult<List<About>> GetAll();
        IDataResult<List<About>> GetAllDeleted();
        IDataResult<About> GetById(int id);
    }
}

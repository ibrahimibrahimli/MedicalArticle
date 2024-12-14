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
    public interface IServiceService
    {
        IResult Add(ServiceCreateDto dto, IFormFile photoUrl, string webRootPath);
        IResult Update(ServiceUpdateDto dto, IFormFile photoUrl, string webRootPath);
        IDataResult<List<Service>> GetAll();
        IDataResult<List<Service>> GetAllDeleted();
        IDataResult<Service> GetById(int id);
        IResult HardDelete(int id); 
        IResult SoftDelete(int id); 
        IResult ReturnDeleted(int id);
        IDataResult<List<ServiceDto>> GetServicesWithCategory();
        IDataResult<List<Service>> GetDataByLanguage(string lang);
    }
}

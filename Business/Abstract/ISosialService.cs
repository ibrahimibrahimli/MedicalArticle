using Core.Results.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISosialService
    {
        IResult Add(SosialCreateDto dto);
        IDataResult<List<Sosial>> GetAll();  
        IDataResult<List<Sosial>> GetAllDeleted();  
        IDataResult<Sosial> GetById(int id);
        IResult HardDelete(int id);
        IResult SoftDelete(int id);
        IResult Update(SosialUpdateDto dto);
        IResult ReturnDeleted(int id);
    }
}

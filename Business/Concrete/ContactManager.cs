using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Dtos;
using Entities.TableModels;
using FluentValidation;

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;
        private readonly IValidator<Contact> _validator;

        public ContactManager(IValidator<Contact> validator, IContactDal contactDal)
        {
            _validator = validator;
            _contactDal = contactDal;
        }

        public IResult Add(ContactCreateDto dto)
        {
            Contact model = ContactCreateDto.ToContact(dto);
            var validator = _validator.Validate(model);

            string errorMessage = "";

            foreach (var error in validator.Errors) 
            {
               errorMessage = error.ErrorMessage;
            }
            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }
            _contactDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage(model.Name));
        }

        public IDataResult<List<Contact>> GetAll()
        {
            return new SuccessDataResult<List<Contact>>(_contactDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<List<Contact>> GetAllDeleted()
        {
            return new SuccessDataResult<List<Contact>>(_contactDal.GetAll(x => x.Deleted != 0));
        }

        public IDataResult<Contact> GetById(int id)
        {
            return new SuccessDataResult<Contact>(_contactDal.GetById(id));
        }

        public IResult HardDelete(int id)
        {
            Contact data = GetById(id).Data;
            _contactDal.Delete(data);

            return new SuccessResult(UiMessages.SuccessDeletedMessage(data.Name));

        }

        public IResult ReturnDeleted(int id)
        {
            Contact data = _contactDal.GetById(id);
            data.Deleted = 0;
            _contactDal.Update(data);
            return new SuccessResult(UiMessages.SuccessReturnTrashMessage(data.Name));
        }

        public IResult SoftDelete(int id)
        {
            Contact data = GetById(id).Data;
            data.Deleted = id;

            _contactDal.Update(data);

            return new SuccessResult(UiMessages.SuccessDeletedMessage(data.Name));
        }

        public IResult Update(ContactUpdateDto dto)
        {
            Contact model = ContactUpdateDto.ToContact(dto);
            Contact existData = GetById(model.Id).Data;
            model.UpdatedDate = DateTime.Now;
            _contactDal.Update(model);

            return new SuccessResult(UiMessages.SuccessUpdatedMessage(existData.Name));
        }
    }
}

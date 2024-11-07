using Business.Abstract;
using Business.Concrete;
using Business.Validations;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.TableModels.Membership;
using Entities.TableModels;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services) 
        {
            services.AddScoped<IAboutDal, AboutDal>();
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IValidator<About>, AboutValidation>();

            services.AddScoped<IAdressDal, AdressDal>();
            services.AddScoped<IAdressService, AdressManager>();
            services.AddScoped<IValidator<Adress>, AdressValidation>();


            services.AddScoped<ICategoryDal, CategoryDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IValidator<Category>, CategoryValidation>();

            services.AddScoped<IContactDal, ContactDal>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IValidator<Contact>, ContactValidation>();

            services.AddScoped<IFaqDal, FaqDal>();
            services.AddScoped<IFaqService, FaqManager>();
            services.AddScoped<IValidator<Faq>, FaqValidation>();

            services.AddScoped<IServiceDal, ServiceDal>();
            services.AddScoped<IServiceService, ServiceManager>();
            services.AddScoped<IValidator<Service>, ServiceValidation>();

            services.AddScoped<ISlideDal, SlideDal>();
            services.AddScoped<ISlideService, SlideManager>();
            services.AddScoped<IValidator<Slide>, SlideValidation>();

            services.AddScoped<ISosialDal, SosialDal>();
            services.AddScoped<ISosialService, SosialManager>();
            services.AddScoped<IValidator<Sosial>, SosialValidation>();

            services.AddScoped<IValidator<ApplicationUser>, ApplicationUserValidation>();
            return services;
        }
    }
}

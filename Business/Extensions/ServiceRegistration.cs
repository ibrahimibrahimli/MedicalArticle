using Business.Abstract;
using Business.Concrete;
using Business.Validations;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.TableModels.Membership;
using Entities.TableModels;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

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

            services.AddScoped<IBlogDal, BlogDal>();
            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IValidator<Blog>, BlogValidation>();


            services.AddScoped<ICategoryDal, CategoryDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IValidator<Category>, CategoryValidation>();

            services.AddScoped<IContactDal, ContactDal>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IValidator<Contact>, ContactValidation>();

            services.AddScoped<ICommentDal, CommentDal>();
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<IValidator<Comment>, CommentValidation>();

            services.AddScoped<IFaqDal, FaqDal>();
            services.AddScoped<IFaqService, FaqManager>();
            services.AddScoped<IValidator<Faq>, FaqValidation>();

            services.AddScoped<IFactDal, FactDal>();
            services.AddScoped<IFactService, FactManager>();
            services.AddScoped<IValidator<Fact>, FactValidation>();

            services.AddScoped<IHealtTipDal, HealtTipDal>();
            services.AddScoped<IHealtTipService, HealtTipManager>();
            services.AddScoped<IValidator<HealtTip>, HealtTipValidation>();

            services.AddScoped<IHealtTipItemsDal, HealtTipItemsDal>();
            services.AddScoped<IHealtTipItemsService, HealtTipItemsManager>();
            services.AddScoped<IValidator<HealtTipItems>, HealtTipItemsValidation>();

            services.AddScoped<IServiceDal, ServiceDal>();
            services.AddScoped<IServiceService, ServiceManager>();
            services.AddScoped<IValidator<Service>, ServiceValidation>();

            services.AddScoped<IServiceAboutDal, ServiceAboutDal>();
            services.AddScoped<IServiceAboutService, ServiceAboutManager>();
            services.AddScoped<IValidator<ServiceAbout>, ServiceAboutValidation>();

            services.AddScoped<IServiceAboutItemsDal, ServiceAboutItemsDal>();
            services.AddScoped<IServiceAboutItemsService, ServiceAboutItemsManager>();
            services.AddScoped<IValidator<ServiceAboutItems>, ServiceAboutItemsValidation>();

            services.AddScoped<ISlideDal, SlideDal>();
            services.AddScoped<ISlideService, SlideManager>();
            services.AddScoped<IValidator<Slide>, SlideValidation>();

            services.AddScoped<ISosialDal, SosialDal>();
            services.AddScoped<ISosialService, SosialManager>();
            services.AddScoped<IValidator<Sosial>, SosialValidation>();

            services.AddScoped<ITeamBoardDal, TeamBoardDal>();
            services.AddScoped<ITeamBoardService, TeamBoardManager>();
            services.AddScoped<IValidator<TeamBoard>, TeamBoardValidation>();

            services.AddScoped<IWhyChooseUsDal, WhyChooseUsDal>();
            services.AddScoped<IWhyChooseUsService, WhyChooseUsManager>();
            services.AddScoped<IValidator<WhyChooseUs>, WhyChooseUsValidation>();

            services.AddScoped<IWhyChooseUsItemsDal, WhyChooseUsItemsDal>();
            services.AddScoped<IWhyChooseUsItemsService, WhyChooseUsItemsManager>();
            services.AddScoped<IValidator<WhyChooseUsItems>, WhyChooseUsItemsValidation>();

            services.AddScoped<ILanguageDal, LanguageDal>();
            services.AddScoped<ILanguageService, LanguageManager>();

            services.AddScoped<IValidator<ApplicationUser>, ApplicationUserValidation>();
            return services;
        }
    }
}

using BusinessLayer.Abstract;
using BusinessLayer.Abstract.AbstractUow;
using BusinessLayer.Concrete;
using BusinessLayer.Concrete.ConcreteUow;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UnitOfWork;
using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class Extensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {


            services.AddScoped<IDestinationDal, EfDestinationDal>();
            services.AddScoped<IDestinationService, IDestinationManager>();
            
            services.AddScoped<IAboutDal, EfAboutDal>();
            services.AddScoped<IAboutService, IAboutManager>();
            
            services.AddScoped<IAbout2Dal, EfAbout2Dal>();
            services.AddScoped<IAbout2Service, IAbout2Manager>();
            
            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<IContactService, IContactManager>();
            
            services.AddScoped<ISubAboutDal, EfSubAboutDal>();
            services.AddScoped<ISubAboutService, ISubAboutManager>();
            
            services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            services.AddScoped<ITestimonialService, ITestimonialManager>();
            
            services.AddScoped<IFeature2Dal, EfFeature2Dal>();
            services.AddScoped<IFeature2Service, IFeature2Manager>();
            
            services.AddScoped<IFeatureDal, EfFeatureDal>();
            services.AddScoped<IFeatureService, IFeatureManager>();
            
            services.AddScoped<IGuideDal, EfGuideDal>();
            services.AddScoped<IGuideService, IGuideManager>();
            
            services.AddScoped<INewsletterDal, EfNewsletterDal>();
            services.AddScoped<INewsletterService, INewsletterManager>();
            
            services.AddScoped<ICommentDal, EfCommentDal>();
            services.AddScoped<ICommentService, ICommentManager>();
            
            services.AddScoped<IResarvationDal, EfResarvationDal>();
            services.AddScoped<IResarvationService, IResarvationManager>();
            
            services.AddScoped<IAppUserDal, EfAppUserDal>();
            services.AddScoped<IAppUserService, IAppUserManager>();

			services.AddScoped<IExcelService, IExcelManager>();

			services.AddScoped<IPdfService, IPdfManager>();

			services.AddScoped<IContactUsDal, EfContactUsDal>();
			services.AddScoped<IContactUsService, IContactUsManager>();

			services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
			services.AddScoped<IAnnouncementService, IAnnouncementManager>();


            services.AddTransient<IValidator<AnnouncementAddDto>,AnnouncementValidator>();

            services.AddScoped<IAccountDal , EfAccountDal>();
            services.AddScoped<IAccountService , AccountManager>();

            services.AddScoped<IUowDal,UowDal>();


        }
    }
}

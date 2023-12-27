using Application.DTOs.Interfaces;
using Application.DTOs.UserDTOs;
using Application.DtoServices.UserServices;
using Application.Interfaces.IDtoServeices;
using Application.Interfaces.IServices;
using Core.Entities;
using Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Dependencies
{
    public static class ApplicationDependencies
    {
        public static IServiceCollection AddAppServices(this
           IServiceCollection Services)
        {



         //   IServiceCollection serviceCollection = Services.AddScoped<IRepository<User>, GenericRepositoy<User>>();

            Services.AddScoped<IUserConverter, UserConverterService>();
           
            Services.AddScoped<IPasswordService, PasswordServices>();
            Services.AddScoped<IUserResponseDTOBuilder, UserResponseDTOBuilder>();
            Services.AddScoped<IUserDto, UserDtoService>();
            // Services.AddDbContext<UserManagerDbContext>();
            //Services.AddScoped<IDTOService<CustomerGetDTO>, DTOCustomerService<CustomerGetDTO>>();
            //Services.AddScoped<IRepository<User>>();

            //Services.AddScoped<IRepository<Customer>, GenericRepository<Customer>>();
            //Services.AddScoped<IRepository<CustOrder>, GenericRepository<CustOrder>>();
            //Services.AddScoped<IRepository<VisaCard>, GenericRepository<VisaCard>>();
            //Services.AddScoped<IRepository<Cart>, GenericRepository<Cart>>();
            //Services.AddScoped<IRepository<CountryData>, GenericRepository<CountryData>>();
            return Services;
        }
    }
}

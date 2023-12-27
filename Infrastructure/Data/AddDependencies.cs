using Application.DTOs;
using Application.DtoServices.UserServices;
using Application.Interfaces.IDtoServeices;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data
{
    public static class AddDependencies
    {
        public static IServiceCollection AddServices(this
            IServiceCollection Services)
        {
           // Services.AddScoped<IUserDto, UserDtoService>();
            Services.AddDbContext<UserManagerDbContext>();
           
            Services.AddScoped<IRepository<User>, GenericRepositoy<User>>();

            Services.AddScoped<IUserDto, UserDtoService>();


            return Services;
        }
    }
}

using HospitalNew.BLL.Interfaces;
using HospitalNew.BLL.Services;
using HospitalNew.BLL.UnitOfWorks;
using HospitalNew.DAL.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalNew.BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBLLServices (this IServiceCollection services, IConfiguration config)
        {
            services.AddDALServices(config);
            services.AddScoped<IAppointmentsService, AppointmentsService>();
            services.AddScoped<IAuthSerice, AuthService>();
            services.AddScoped<IDoctorGenericService, DoctorGenericService>();
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped<IInvoicesService, InvoicesService>();
            services.AddScoped<IPatientsService, PatientsService>();
            services.AddScoped<ISpecialtiesService, SpecialtiesService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUsersService, UsersService>();
            return services;
        }
    }
}

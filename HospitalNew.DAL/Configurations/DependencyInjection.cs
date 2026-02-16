using HospitalNew.DAL.Data;
using HospitalNew.DAL.Interfaces;
using HospitalNew.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalNew.DAL.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDALServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}

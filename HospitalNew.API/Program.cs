using HospitalNew.BLL;
using HospitalNew.DAL.Configurations;
using HospitalNew.DAL.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

namespace HospitalNew.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ================= JWT CONFIG VALIDATION =================
            var jwtSection = builder.Configuration.GetSection("JWT");
            var jwtSecret = jwtSection["Secret"];

            if (string.IsNullOrEmpty(jwtSecret))
            {
                throw new Exception("JWT Secret is missing. Check User Secrets or appsettings.");
            }
            // ==========================================================


            // ================= CONTROLLERS & JSON =================
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });
            // ========================================================


            // ================= SWAGGER =================
            builder.Services.AddEndpointsApiExplorer(); 
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Hospital API",
                    Version = "v1"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your token"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
            // ========================================================


            // ================= DATABASE =================
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            // ========================================================


            // ================= AUTHENTICATION (JWT) =================
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = jwtSection["Issuer"],
                        ValidAudience = jwtSection["Audience"],

                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtSecret)
                        )
                    };
                });
            // ========================================================


            // ================= OTHER SERVICES =================
            builder.Services.AddCors();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddBLLServices(builder.Configuration);
            builder.Services.AddDALServices(builder.Configuration);
            // ========================================================


            var app = builder.Build();

            // ================= MIDDLEWARE =================
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(c =>
                c.AllowAnyHeader()
                 .AllowAnyMethod()
                 .AllowAnyOrigin());

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
            // ========================================================
        }
    }
}

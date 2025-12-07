using System.Text;
using Erp.Application.Auth.Commands;
using Erp.Application.Common.Interfaces;
using Erp.Infrastructure.Identity;
using Erp.Infrastructure.Persistence;
using Erp.Infrastructure.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Erp.Application.Requests.ErpApp.Helper.Country;


using Erp.Application.Requests.ErpApp.Helper.BuyerSizeSet;



using Erp.Application.Auth.RoleManagement;
using Erp.Infrastructure.Services.ErpApp.Notifications;
using Erp.Application.Common.Notifications;
using Erp.Application.Common.Supervisors;



using Erp.Application.Requests.ErpApp.SCHOOL;

using Erp.Application.Requests.ErpApp.SCHOOL.File;
using Erp.Infrastructure.Filter;
using Erp.Infrastructure.Auth.RoleManagement;
using Erp.Application.Requests.ErpApp.Commercial.Setup;
using Erp.Infrastructure.Services. MascoWash;
using Erp.Application.Commercial.Setup.Command;
using Erp.Application.Commercial.Setup;
using Erp.Application.MascoWash.Setup.Repository;

namespace Erp.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(x =>
            {
                x.UseLazyLoadingProxies();
                x.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            IdentityBuilder builder = services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 4;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
            //builder.AddEntityFrameworkStores<ApplicationDbContext>();
            builder.AddRoleValidator<RoleValidator<Role>>();
            builder.AddRoleManager<RoleManager<Role>>();
            builder.AddSignInManager<SignInManager<User>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateLifetime = false,
                        ValidateAudience = false,
                    };
                });

            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

                options.Filters.Add(new AuthorizeFilter(policy));
            });

            //services.AddScoped<AuthorizationFilter>();
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<ILogToDatabaseService, LogToDatabaseService>();
            /*Menu*/
            services.AddTransient<ICreateMenuPermission, SetupService>();
            services.AddTransient<ISaveDataList, SetupServices>();
       
            services.AddTransient<ISetup, SetupServices>();
            services.AddTransient<ReportService>();
            /* dependencies interfaces need to register here other wise
            Error constructing handler for request of type MediatR.IRequestHandler*/



            //procurement 



            // purchase order setting


            //new adder

            //end
            //services.AddTransient<Application.Requests.ErpApp.Helper.Country.ICountryService, CountryService>();

            //Booking Instruction















            //Buyer Department
            //services.AddTransient<IBuyerDepartmentService, BuyerDepartmentService>();

            //Buyer Size Set
            //services.AddTransient<IBuyerSizeSetService, BuyerSizeSetService>();










            ///*HttpClient*/
            services.AddHttpClient<IIdentityService, IdentityService>();

     
           


    
 
            //Bill Of Material

      

     

            //acounting
  
            services.AddTransient<INotifications, NotificationService>();
   
 
            //MMS
     
 
         
      

          

           
           
           // services.AddTransient<IUserRoll, UserRollService>();



            return services;
        }
    }
}

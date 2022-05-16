using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rusada.Business.Managers;
using Rusada.Common.CommenModel;
using Rusada.Common.Interfases;
using Rusada.Common.Managers;
using Rusada.Common.Mappers;
using Rusada.Data.Mappers;
using Rusada.Data.Repositories;
using Rusada.DataContext;
using System.Configuration;

namespace Rusada.Business.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region DbContext
            services.AddDbContext<RsadaDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            #endregion

            #region HttpContext
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            services.AddTransient<IEntityMapper, EntityMapper>();

            services.AddTransient<IErrorMessages, ErrorMessages>();

            //#region Managers
            services.AddTransient<ISpotterManager, SpotterManager>();

            //#endregion

            //#region Repository
            services.AddTransient<ISpotterRepositories, SpotterRepositories>();
            //#endregion

            #region Mappers
            services.AddSingleton<IEntityMapper, EntityMapper>();
            services.AddSingleton<IMapper<IList<Message>, ServiceResponse>, ServiceErrorMapper>();
            services.AddSingleton<IMapper<object, ServiceResponse>, ServiceResponseMapper>();
            services.AddSingleton<IMapper<(IList<Message>, object), ServiceResponse>, ServiceErrorWithReturnMapper>();
            #endregion

            services.AddLogging();
            return services;
        }
    }
}
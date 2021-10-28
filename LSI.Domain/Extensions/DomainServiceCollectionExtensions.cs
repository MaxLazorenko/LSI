using LSI.Domain.Behaviors;
using LSI.Domain.Storage;
using LSI.Domain.Storage.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LSI.Domain.Extensions
{
    public static class DomainServiceCollectionExtensions
    {
        public static void RegisterDomainServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(IDomainAssemblyLocator));
            services.AddDbContext<ReportContext>();
            services.AddScoped<DataSeeder>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddMediatR(typeof(IDomainAssemblyLocator));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
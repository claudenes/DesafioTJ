using Ambev.Infra.Data.Repositories;
using DesafioTJ.Application.Interfaces;
using DesafioTJ.Application.Mappings;
using DesafioTJ.Application.Services;
using DesafioTJ.Domain.Interfaces;
using DesafioTJ.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioTJ.Infra.IoC
{
    public static class DependencyInjection
    {
       
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureEntityFrameWork(services);
            services.AddScoped<IAssuntoRepository, AssuntoRepository>();
            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<ILivroAssuntoRepository, LivroAssuntoRepository>();
            services.AddScoped<ILivroAutorRepository, LivroAutorRepository>();
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));

            var myhandlers = AppDomain.CurrentDomain.Load("Ambev.Application");

            return services;
        }
        private static void ConfigureEntityFrameWork(this  IServiceCollection services)
        {
            string connectionString = "";

            connectionString = @"Data Source=DESKTOP-OAG94LR\SQLEXPRESS;Initial Catalog=DESAFIOTJ;Integrated Security=True;";

            services.AddDbContext<ApplicationDbContext>(options =>
            {

                options.UseSqlServer(connectionString,
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)); options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

        }
        public static IServiceCollection AddServices(this IServiceCollection services) 
        {
            
            services.AddScoped<IAssuntoService, AssuntoService>();
            services.AddScoped<IAutorService, AutorService>();
            services.AddScoped<ILivroAssuntoService, LivroAssuntoService>();
            services.AddScoped<ILivroAutorService, LivroAutorService>();
            services.AddScoped<ILivroService, LivroService>();
            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));
            return services;
        }
    }
    
}

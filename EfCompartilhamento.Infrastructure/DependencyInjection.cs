using EfCompartilhamento.Domain.Repositories;
using EfCompartilhamento.Infrastructure.Context;
using EfCompartilhamento.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCompartilhamento.Infrastructure
{
    public static class DependencyInjection
    {
        public const string ConnectionString = "Data Source=127.0.0.1,1433; Initial Catalog = meu-banco;User Id=Admin;Password=SuperSenha2000!;Min Pool Size=10;Max Pool Size=20;Command Timeout=60;Pooling=False;TrustServerCertificate=True";

        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddSqlServer();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ILibraryRepository, LibraryRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
        }

        private static void AddSqlServer(this IServiceCollection services)
        {
            services.AddDbContext<CompartilhamentoDbContext>(options =>
                options.UseSqlServer(ConnectionString,
                    action => action.MigrationsAssembly("EfCompartilhamento.Infrastructure").EnableRetryOnFailure()).EnableDetailedErrors()
                );
        }
    }
}

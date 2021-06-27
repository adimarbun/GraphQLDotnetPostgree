using GrapqlDotnetPostgree.Data;
using GrapqlDotnetPostgree.GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GraphQL.Server.Ui.Voyager;
using GrapqlDotnetPostgree.GraphQL.Platform;
using GrapqlDotnetPostgree.GraphQL.Command;

namespace GrapqlDotnetPostgree
{
    public class Startup
    {
        public readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionstring ="Host=localhost;Database=graphqldotnet;Username=postgres;Password=admin";
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(connectionstring, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                });

            }, optionsLifetime: ServiceLifetime.Transient);

            services.AddDbContextFactory<AppDbContext>();

            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<PlatformType>()
                .AddType<CommandType>()
                .AddFiltering()
                .AddSorting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

            app.UseGraphQLVoyager(new GraphQLVoyagerOptions()
            {
                GraphQLEndPoint = "/graphql",
                Path = "/graphql-voyager"
            });
        }
    }
}

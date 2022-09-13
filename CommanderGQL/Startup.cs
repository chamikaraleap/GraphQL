using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommanderGQL.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GraphQL.Server.Ui.Voyager;
using CommanderGQL.GraphQL;
using CommanderGQL.GraphQL.Platforms;

namespace CommanderGQL
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<AppDbContext>(opt =>
            opt.UseSqlServer(_configuration.GetConnectionString("CommandConnStr")));

            services
            .AddGraphQLServer()
            .AddQueryType<Query>()
            .AddType<PlatformType>();
        }


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

            app.UseGraphQLVoyager(new VoyagerOptions(){
                GraphQLEndPoint = "/graphql",

            }, "/ui/voyager");
        }
    }
}

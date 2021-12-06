using Application;
using Application.Common.Interfaces;
using Infraestructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ToDo.Api.Extensions;
using ToDo.Api.Services;

namespace ToDo.Api
{
    public class Startup
    {
        private readonly string _loginOrigin = "_localorigin";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Service Extensions

            services.AddApplication();
            services.AddInfrastructure(Configuration);

            #endregion Service Extensions

            #region Cors

            services.AddCors(options =>
            {
                options.AddPolicy(_loginOrigin, builder => builder.AllowAnyOrigin()
                                                                   .AllowAnyHeader()
                                                                   .AllowAnyMethod());
            });

            #endregion Cors

            services.AddSingleton<ICurrentUserService, CurrentUserService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDo.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDo.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors(_loginOrigin);

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            #region Middleware

            app.UseErrorHandlingMiddleware();

            #endregion Middleware

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
using Application.Application;
using Application.IApplication;
using Infrastructure.Application.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Infrastructure.Repositories;
using Infrastructure.IRepositories;
using Infrastructure.IRepository;
using Infrastructure.Repository;
using RestApi.Filters;
using Microsoft.EntityFrameworkCore;


namespace RestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("PersonalManagementDb");
            services.AddMvc(options => {
                options.Filters.Add<RequiredHttpsOrCloseAttribiute>();
                options.Filters.Add<JsonExceptionFilter>();
                });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyApp", policy => policy.AllowAnyOrigin());
            });
          
            services.AddDbContext<ApplicationContext>(builder => builder.UseSqlServer(connectionString));
            
            services.AddTransient<ICategoryApplication,CategoryApplication>();
            services.AddScoped<CategoryRepository>();

            services.AddControllers().AddControllersAsServices(); ;
       
            services.AddSwaggerDocument();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseCors();
            app.UseRouting();

            app.UseAuthorization();
        

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MMS.Domain.Distributors.Repositories;
using MMS.Domain.Products.Repositories;
using MMS.Domain.Sales.Repository;
using MMS.Domain.Services;
using MMS.Domain.Services.Products;
using MMS.Domain.Services.Sales;
using MMS.Infrastructure.Db;
using MMS.Infrastructure.Repositories;

namespace MMS.Api
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

            services.AddCors();
            services.AddResponseCompression();

            services.AddDbContextPool<AppDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("AppDbContext")));

            services.AddScoped<IDistributorRepository, DistributorRepository>();
            services.AddScoped<IDistributorService, DistributorService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ISaleService, SaleService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MMS.Api", Version = "v1" });
            });

            InitializeDatabase(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceScopeFactory scopeFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MMS.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void InitializeDatabase(IServiceCollection services)
        {
            var sp = services.BuildServiceProvider();
            var db = sp.GetService(typeof(AppDbContext)) as AppDbContext;
            db?.Database.EnsureCreated();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Solid.OpenClosed
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
			services.AddControllers();

			services.AddTransient<Handlers.IGetEmployeeHandler, Handlers.GetEmployeeHandler>();
			services.AddTransient<Data.Sqlite.Adapters.IEmployeeAdapter, Data.Sqlite.Adapters.EmployeeAdapter>();

			// next two lines configure the Sqlite repository
			services.AddDbContext<Data.Sqlite.IEmployeeDbContext, Data.Sqlite.EmployeeDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("EmployeeContext")));
			services.AddScoped<Data.Repositories.IEmployeeRepository, Data.Sqlite.EmployeeRepository>();

			// following line to use the InMemoryRepository instead of Sqlite
			//services.AddSingleton<Data.Repositories.IEmployeeRepository, Data.InMemory.InMemoryEmployeeRepository>();

			services.AddAutoMapper(typeof(Startup));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}

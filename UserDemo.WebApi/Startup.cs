using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserDemo.Business.Abstract;
using UserDemo.Business.Concrete;
using UserDemo.DataAccess.Abstract;
using UserDemo.DataAccess.Concrete.EfCore;
using UserDemo.WebApi.Middlewares;

namespace UserDemo.WebApi
{
	public class Startup
	{
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {

			services.AddControllers();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IUserDal, UserDal>();
			services.AddSwaggerDocument();
			services.AddDistributedRedisCache(x => { x.Configuration = "localhost: 6379"; });
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();
			app.UseOpenApi();
			app.UseSwaggerUi3();//UI için
			app.UseMiddleware<BasicAuthenticationMiddleware>();
			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
			});
		}
	}
}

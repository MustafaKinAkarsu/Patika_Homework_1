using FluentValidation;
using Microsoft.OpenApi.Models;
using Patika_HW_1.Models;
using Patika_HW_1.Validations;
using System;

namespace Patika_HW_1;
public class Startup
{
	public IConfiguration Configuration;

	public Startup(IConfiguration configuration)
	{
		this.Configuration = configuration;
	}


	public void ConfigureServices(IServiceCollection services)
	{

		services.AddControllers();
		services.AddScoped<IValidator<Product>, ProductValidator>();
		services.AddSwaggerGen(c =>
		{
			c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pa.Api", Version = "v1" });
		});
	}

	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
			app.UseSwagger();
			app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pa.Api v1"));
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
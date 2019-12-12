using FlightApp.Backend.Data;
using FlightApp.Backend.Data.Repositories.Concrete;
using FlightApp.Backend.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlightApp.Backend
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

      services.AddDbContext<ApplicationDbContext>(options =>
      {
        options.UseSqlServer(Configuration.GetConnectionString("DevConnection"));
      });

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

      services.AddScoped<FlightAppInit>();
      services.AddScoped<IFlightRepository, FlightRepository>();
      services.AddScoped<IPlaneRepository, PlaneRepository>();
      services.AddScoped<ISeatRepository, SeatRepository>();
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<IStaffRepository, StaffRepository>();
      services.AddScoped<IUserFlightRepository, UserFlightRepository>();

      services.AddOpenApiDocument(c =>
      {
        c.DocumentName = "apidocs";
        c.Title = "FlightApp API";
        c.Version = "v1";
        c.Description = "The FlightApp API documentation description.";
      });

      services
        .AddCors(options => options.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin()));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, FlightAppInit flightAppInit)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseCookiePolicy();

      app.UseCors("AllowAllOrigins");

      app.UseMvc();

      app.UseSwaggerUi3();
      app.UseSwagger();

      //flightAppInit.Init();
    }
  }
}

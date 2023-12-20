using Application;
using Persistence;
using AutoMapper;
using System.Reflection;
using Application.Queries;
using MediatR;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            builder.Services.AddAutoMapper(typeof(AssemblyMappingProfile).Assembly);
            //builder.Services.AddApplication();
            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            builder.Services.AddControllers();

            builder.Services.AddCors(
                options =>
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                })
                );

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {

                }
            }
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.MapControllers();
            //app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
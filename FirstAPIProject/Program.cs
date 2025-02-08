
using FirstAPIProject.DAL.Models;
using FirstAPIProject.DAL.Context;
using Microsoft.EntityFrameworkCore;
using FirstAPIProject.DAL.Repo;

namespace FirstAPIProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            //builder.Services.AddOpenApi();

            //builder.Services.AddDbContext<ClinicDBContext>(
            //    options => options.UseSqlServer("Data Source=.;Initial Catalog=ClinicDB;Integrated Security=true;Encrypt=false;"));

            //to allow using dependency injection for dbcontext
            builder.Services.AddDbContext<ClinicDBContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //builder.Services.AddDbContext<ClinicDBContext>(
            //    options => options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));

            builder.Services.AddScoped<IPatientRepository, PatientRepository>();

            builder.Services.AddEndpointsApiExplorer(); // Enable API explorer
            builder.Services.AddSwaggerGen(); // Add Swagger

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(); // Enable Swagger UI
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

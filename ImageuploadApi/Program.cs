
using ImageuploadApi.Models.Domain;
using ImageuploadApi.Repository.Abstract;
using ImageuploadApi.Repository.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Net.NetworkInformation;

namespace ImageuploadApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<DatabaseContext>(options
                => options.UseSqlServer(builder.Configuration.GetConnectionString("Con")));

            builder.Services.AddTransient<IFileService, FileService>();
            builder.Services.AddTransient<IProductRepository, ProductRepository>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseStaticFiles(
                new StaticFileOptions
                {
                    FileProvider=new PhysicalFileProvider(
                        Path.Combine(builder.Environment.ContentRootPath,"Uploads")),
                    RequestPath="/Resources"
                });
            app.UseHttpsRedirection();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

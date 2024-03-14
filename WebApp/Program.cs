using Data.Data;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using WebApp.Infrastructure;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);   

            // Services configuration
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<TodoDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDb"));
            });
            builder.Services.AddScoped<ITodoTaskRepository, TodoTaskRepository>();
            builder.Services.AddAutoMapper(typeof(MapperProfile));

            var app = builder.Build();

            app.MapDefaultControllerRoute();
            app.UseStaticFiles();

            app.Run();
        }
    }
}

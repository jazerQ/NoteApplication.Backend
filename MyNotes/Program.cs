
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace MyNotes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);           
            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddDbContext<NoteDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnectionString"));
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("http://localhost:3000");
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                });
            });
            builder.Services.AddSwaggerGen();
            builder.Services.GetAllDependencies();
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors();
            app.MapControllers();
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.Run();
        }
    }
}

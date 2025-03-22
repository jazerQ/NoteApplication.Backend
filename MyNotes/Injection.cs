using Application;
using DataAccess.Repositories;
using Domain.Abstractions;

namespace MyNotes
{
    public static class Injection
    {
        public static IServiceCollection GetAllDependencies(this IServiceCollection services) 
        {
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<INoteService, NoteService>();

            return services;
        }
    }
}

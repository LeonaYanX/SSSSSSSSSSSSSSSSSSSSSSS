
using GraphQlSeminar.Abstractions;
using GraphQlSeminar.DbModels;
using GraphQlSeminar.Graph.Mutation;
using GraphQlSeminar.Graph.Query;
using GraphQlSeminar.Mapper;
using GraphQlSeminar.Repository;
using Microsoft.EntityFrameworkCore;

namespace GraphQlSeminar
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            

           // builder.Services.AddControllers();
          
            builder.Services.AddEndpointsApiExplorer();
           // builder.Services.AddSwaggerGen();
           builder.Services.AddDbContext<StorageDbContext>(options=>options.UseNpgsql(builder.Configuration.GetConnectionString("db")));
           // регистрация контекста подключения к базе данных
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<IProductRepository, ProductRepository>(); // регистрация репозитория
            builder.Services.AddScoped<IProductGroupRepository, ProductGroupRepository>(); // регистрация репозитория
            builder.Services.AddScoped<IStorageRepository, StorageRepository>(); // регистрация репозитория - service
            builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>(); // регистрация GraphQL
            builder.Services.AddMemoryCache();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
           /* if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }*/

            app.UseHttpsRedirection();

            // app.UseAuthorization();

            app.MapGraphQL();
           // app.MapControllers();

            app.Run();
        }
    }
}

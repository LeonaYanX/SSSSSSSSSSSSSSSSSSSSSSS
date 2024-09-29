
using Autofac;
using Autofac.Extensions.DependencyInjection;
using SSSSSSSSSSSSSSSSSSSSSSS.Abstractions;
using SSSSSSSSSSSSSSSSSSSSSSS.DbModels;
using SSSSSSSSSSSSSSSSSSSSSSS.Mapper;
using SSSSSSSSSSSSSSSSSSSSSSS.Repository;

namespace SSSSSSSSSSSSSSSSSSSSSSS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

          

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>      // cheres autofac tut zaregistrirovat
                                                                                       // servis ato budet dispose exeption
            {
               containerBuilder.RegisterType<ProductRepository>().As<IProductRepository>();
                containerBuilder.RegisterType<ProductGroupRepository>().As<IProductGroupRepository>();
                containerBuilder.Register(x=>new StorageDbContext(builder.Configuration.GetConnectionString("db")))
                .InstancePerDependency();
            });

            builder.Services.AddMemoryCache(o=>o.TrackStatistics=true);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

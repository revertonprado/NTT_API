using Microsoft.EntityFrameworkCore;
using NTT_API.Data;
using NTT_API.Repository;

namespace NTT_API
{

    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<EstabecimentoDBContex>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("API_NTTContext") ?? throw new InvalidOperationException("Connection string 'API_NTTContext' not found.")));

            builder.Services.AddScoped<IEstabelecimentoRepository, EstabelecimentoRepository>();

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


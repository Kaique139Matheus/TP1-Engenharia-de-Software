using BookingDatabase.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>{
            options.AddPolicy("AllowFrontend",
                builder =>{
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                }
            );
        }
        );


        services.AddControllers();
        services.AddDbContext<EasyBookingContext>(options =>
            options.UseSqlite("Data Source=easybooking.db"));

        // Adicionando Swagger 
        services.AddSwaggerGen();

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        //Abre servidor para requisições do AllowFrontend
        app.UseCors("AllowFrontend");

        // Habilitando o middleware para gerar JSON de especificações do Swagger e a UI do Swagger
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json","EasyBooking");
            c.RoutePrefix = string.Empty; // Para acessar o Swagger na raiz da aplicação
        });

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

}

using CSE.Extension.ServiceCollection;
using Microsoft.EntityFrameworkCore;
using CBS.DataContext;
using CBS.Entity;
using CSE.Interfaces.IApi;
using CSE.Generic.Extension;
using System.Reflection;
using CSE.Response.Api;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



#region Swagger

#if !DEBUG
builder.Services.AddSwagger(true); // Aggiungi il supporto Swagger dalle estenzioni personalizzate
#else
builder.Services.AddSwagger(false);
#endif
#endregion

#region DbContext BusinessLogic
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
#endregion

#region Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

#endregion

#region Repository and Service

builder.Services.AddData<DataContext>(Assembly.GetAssembly(typeof(EntityAssembly)));

builder.Services.AddScoped(typeof(IApiResponse<>), typeof(ApiResponse<>));

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

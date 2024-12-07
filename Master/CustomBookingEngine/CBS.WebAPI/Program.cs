using CSE.Extension.ServiceCollection;
using Microsoft.EntityFrameworkCore;
using CBS.DataContext;
using CBS.Entity;
using CSE.Interfaces.IApi;
using CSE.Generic.Extension;
using System.Reflection;
using CSE.Response.Api;
using CBS.Entity.Domain;
using CBS.Core.Interfaces;
using CBS.Core.Services;
using CSE.Service.Dapper;

var builder = WebApplication.CreateBuilder(args);

#region .Net Aspire
builder.AddServiceDefaults();
builder.Services.AddProblemDetails();
#endregion

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


builder.Services.AddScoped<IDapperService>(provider =>
    new DapperService<DataContext>(provider.GetRequiredService<DataContext>(), "public"));


builder.Services.AddScoped(typeof(IApiResponse<>), typeof(ApiResponse<>));

builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IBookingRoomDetailsService, BookingRoomDetailsService>();
builder.Services.AddScoped<IBookingServiceDetailsService, BookingServiceDetailsService>();
builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IRoomTypeService, RoomTypeService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IRoomService, RoomService>();

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

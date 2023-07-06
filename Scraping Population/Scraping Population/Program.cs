using Business_Logic_Layer.BL_Interface;
using Business_Logic_Layer.BL_Service;
using Data_Access_Layer;
using Data_Access_Layer.DL_Interface;
using Data_Access_Layer.DL_Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<ApplicationDbContext>();


builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("policy",
        builder =>
        {
            builder.WithOrigins("http://http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .SetIsOriginAllowed((host) => true);

        });
});

builder.Services.AddScoped<IBLAllDataModelRepository, AllDataModelDataServiceInBLL>();
builder.Services.AddScoped<IDLAllDataModelRepository, AllDataModelDataInDB>();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("policy");

app.MapControllers();

app.Run();

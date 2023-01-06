using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Product.API.Models;
using Product.API.Repositories.Category;
using Product.API.Repositories.Product;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ProductStoreDatabaseSettings>(
                builder.Configuration.GetSection(nameof(ProductStoreDatabaseSettings)));

builder.Services.AddSingleton<IProductStoreDatabaseSettings>(sp =>
       sp.GetRequiredService<IOptions<ProductStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("ProductStoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add CORS
builder.Services.AddCors();

var app = builder.Build();

//Configure the HTTP request pipeline.
app.UseCors(options =>
                options.WithOrigins(builder.Configuration["ApplicationSettings:Client_URL"].ToString())
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

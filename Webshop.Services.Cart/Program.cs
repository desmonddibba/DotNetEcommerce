using Microsoft.EntityFrameworkCore;
using Webshop.Services.CartAPI.Data;
using Webshop.Services.CartAPI.Service;
using Webshop.Services.CartAPI.Service.IService;

var builder = WebApplication.CreateBuilder(args);

// Connection set up

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


// Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Httpclient
builder.Services.AddHttpClient("Product", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ServiceUrl:ProductAPI"]);
});

builder.Services.AddHttpClient("Coupon", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ServiceUrl:CouponAPI"]);
});


builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICouponService, CouponService>();


// Controller
builder.Services.AddControllers();
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Migrate when program run
ApplyMigration();

app.Run();


void ApplyMigration()
{
    using (var scope = app.Services.CreateScope())
    {
        var _db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        if (_db.Database.GetPendingMigrations().Count() > 0)
        {
            _db.Database.Migrate();
        }
    }
}
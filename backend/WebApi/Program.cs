using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.Database;

//SERVICE CONFIGURATION
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingConfigurations).Assembly);
builder.Services.AddDbContext<RestaurantDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();


var app = builder.Build();

// Veritabanını seed et
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<RestaurantDbContext>();
        DbSeeder.Seed(context); // DbSeeder'ı çağır
    }
    catch (Exception ex)
    {
        // Hata yönetimi
        Console.WriteLine(ex.Message);
    }
}

// MIDDLEWARE CONFIGS
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();



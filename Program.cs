using azproductapi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AzproductDbContext>();
builder.Services.AddControllers();
var app = builder.Build();

 
app.UseSwagger();
app.UseSwaggerUI();
//app.UseHttpsRedirection();



app.MapGet("/", () =>
{
    return "Hello, Test";
});

app.MapControllers();
app.Run();

 
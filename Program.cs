var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("BetOnline", c =>
{
    c.BaseAddress = new Uri("https://api.betonline.ag/");
    // Add headers or authentication if needed
});
builder.Services.AddHttpClient("Pinnacle", c =>
{
    c.BaseAddress = new Uri("https://api.pinnacle.com/");
    // Add headers or authentication if needed
}); ;
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

using DemoJWT_MySQL.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomDbContext(builder);

builder.Services.RegisterApiServices();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
                    policy => policy.AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .SetIsOriginAllowed(origin => true)
                                    .AllowCredentials());
});

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

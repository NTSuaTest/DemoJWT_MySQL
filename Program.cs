using DemoJWT_MySQL.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomDbContext(builder);

builder.Services.RegisterApiServices();

builder.Services.AddJWT(builder);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
                    policy => policy.AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .SetIsOriginAllowed(origin => true)
                                    .AllowCredentials());
});

builder.Services.AddSwagger();

builder.Services.RegisterCustomServices();

var app = builder.Build();

app.UseCors("CorsPolicy");

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

app.Run();

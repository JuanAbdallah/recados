var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//// Configure CORS policy
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowSpecificOrigins",
//        builder =>
//        {
//            builder.WithOrigins("https://localhost:7190") // The URL of your Blazor app
//                   .AllowAnyMethod()
//                   .AllowAnyHeader()
//                   .AllowCredentials(); // Optional: if you need to allow credentials
//        });
//});
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Apply the CORS policy
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
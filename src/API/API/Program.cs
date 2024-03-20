using Application;
using Microsoft.Extensions.FileProviders;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddPersistenceService(builder.Configuration);
builder.Services.AddApplicationService();

//Configure IFileProvider
builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(
    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")
    ));

//enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", pol =>
    {
        pol.AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins("https://localhost:44338");
    });
});

builder.Services.AddControllers();
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

app.UseStaticFiles(); //cho phép truy cập các tệp tĩnh từ wwwroot, chẳng hạn như xem hình ảnh

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

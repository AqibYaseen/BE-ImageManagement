using BE_ImageManagement.Interfaces;
using BE_ImageManagement.Services;
using BE_ImageManagement.Utils;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddSingleton<IImageService,ImageService>();
builder.Services.AddSingleton<ImageUtils>(new ImageUtils(builder.Environment.WebRootPath));

builder.Services.AddCors();

var app = builder.Build();


app.UseCors(options =>
{
    options.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
});


if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Sverlov.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connStr = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlite(connStr);
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseStaticFiles();
//app.UseStaticFiles(new StaticFileOptions
//    {
//        FileProvider=new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath,"images")),
//        RequestPath="/images"
//    }
    
//    );

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

//await DbInit.SetupAsync(app);

app.Run();

using Notes2Quiz.BL.Application;
using Notes2Quiz.BL.Impl.Module;
using Notes2Quiz.Web.API.Module;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

{
    var businessLogicModule = new BusinessLogicModule();
    businessLogicModule.RegisterTypes(builder.Services);

    var webApiModule = new N2qWebApiModule();
    webApiModule.RegisterTypes(builder.Services);

    builder.Services.Configure<IApplicationSettings>(builder.Configuration.GetSection("AppSettings"));
}

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

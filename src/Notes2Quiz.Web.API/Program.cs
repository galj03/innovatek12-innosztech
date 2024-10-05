using Microsoft.OpenApi.Models;
using Notes2Quiz.BL.Impl.Module;
using Notes2Quiz.Web.API.Filters;
using Notes2Quiz.Web.API.Module;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Notes2Quiz Web API",
        Description = "The purpose of the Notes2Quiz application is to make learning easier via an automatic quiz generation interface.",
    });
    var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
    options.ParameterFilter<SwaggerParameterFilter>();
    options.IncludeXmlComments(filePath);
});

{
    var businessLogicModule = new BusinessLogicModule();
    businessLogicModule.RegisterTypes(builder.Services);

    var webApiModule = new N2qWebApiModule();
    webApiModule.RegisterTypes(builder.Services);
}

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
//        options => builder.Configuration.Bind("JwtSettings", options)); //TODO: configure

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

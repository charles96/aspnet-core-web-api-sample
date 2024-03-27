using System.Text.Json.Serialization;
using aspnet_core_web_api_sample;
using aspnet_core_web_api_sample.Converters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

logger.Trace("init start");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddHttpClient();
    builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
    builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
    builder.Services.AddSwaggerGen(options => {
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "aspnet-core-web-api-sample.xml"));
        options.MapType<DateOnly>(() => new OpenApiSchema { Type = "string", Example = new OpenApiString("2022-10-31") });
        options.MapType<DateTime>(() => new OpenApiSchema { Type = "string", Example = new OpenApiString("2022-10-31 23:59:59") });
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "API Title",
            Description = "API Description",
            TermsOfService = new Uri("https://example.test"),
            Contact = new OpenApiContact
            {
                Name = "Contact",
                Url = new Uri("https://example.test")
            }
        });
    });
    builder.Services.AddControllers() //options => options.Filters.Add<HttpResponseExceptionFilter>()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter());
                        options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
                        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    });

    builder.Services.AddApiVersioning(o =>
    {
        o.AssumeDefaultVersionWhenUnspecified = true;
        o.DefaultApiVersion = new ApiVersion(1, 0);
        o.ReportApiVersions = true;
        o.ApiVersionReader = ApiVersionReader.Combine(
            new QueryStringApiVersionReader("api-version"),
            new HeaderApiVersionReader("X-Version"),
            new MediaTypeApiVersionReader("ver"));
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger(options => { });
        app.UseSwaggerUI(o => { o.DocumentTitle = "³×ÀÌ¹ö ÇýÅÃ Template API"; });
    }

    app.UseMiddleware<TraceIdMiddleware>();
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "init failed");
}
finally
{
    LogManager.Shutdown();
}
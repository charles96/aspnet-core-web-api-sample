using System.Text.Json.Serialization;
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
    builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
    builder.Services.AddSwaggerGen(options => {
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "aspnet-core-web-api-sample.xml"));
        options.MapType<DateOnly>(() => new OpenApiSchema { Type = "string", Example = new OpenApiString("2022-10-31") });
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "네이버 혜택 Template API",
            Description = "루나 소프트를 통해 발송 될 네이버 혜택 메시지의 Template을 관리하는 API입니다.",
            TermsOfService = new Uri("https://lunasoft.co.kr/home/main/page/policy/terms"),
            Contact = new OpenApiContact
            {
                Name = "Contact",
                Url = new Uri("https://lunasoft.co.kr/home/main/page/company/intro")
            }
        });
    });
    builder.Services.AddControllers() //options => options.Filters.Add<HttpResponseExceptionFilter>()
                    .AddJsonOptions(options =>
                    {
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

    //builder.Host.ConfigureServices(services => services.AddSingleton<NaverBenefitTemplate>());

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger(options => { });
        app.UseSwaggerUI(o => { o.DocumentTitle = "네이버 혜택 Template API"; });
    }

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
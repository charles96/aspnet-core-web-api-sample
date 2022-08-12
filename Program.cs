using System.Text.Json.Serialization;
using aspnet_core_web_api_sample.Converters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
builder.Services.AddSwaggerGen(options => {
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "aspnet-core-web-api-sample.xml"));
    options.MapType<DateOnly>(() => new OpenApiSchema { Type = "string", Example = new OpenApiString("2022-10-31") });
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "���̹� ���� Template API",
        Description = "�糪 ����Ʈ�� ���� �߼� �� ���̹� ���� �޽����� Template�� �����ϴ� API�Դϴ�.",
        TermsOfService = new Uri("https://lunasoft.co.kr/home/main/page/policy/terms"),
        Contact = new OpenApiContact
        {
            Name = "Contact",
            Url = new Uri("https://lunasoft.co.kr/home/main/page/company/intro")
        }
    });
});
builder.Services.AddControllers()
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
    app.UseSwaggerUI(o => { o.DocumentTitle = "���̹� ���� Template API"; });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

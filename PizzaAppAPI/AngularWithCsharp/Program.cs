using PizzaApp.Helpers.DIContainer;
using PizzaApp.Helpers.Extensions;
using PizzaApp.Mappers.MapperConfig;

var builder = WebApplication.CreateBuilder(args);
var appSettings = builder.Configuration.GetSection("AppSettings");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly)
                .AddPostgreSqlDbContext(appSettings)
                .AddAuthentication()
                .AddJwt(appSettings)
                .AddIdentity()
                .AddCors()
                .AddSwagger();

//how to make object for saving the values from appsettings.json to AppSettings class
//builder.Services.Configure<AppSettings>(appSettings);
//AppSettings appSettingsObject = appSettings.Get<AppSettings>();

//var connectionString = appSettingsObject.ConnectionString;
//builder.Services.AddDbContext<PizzaAppDbContext>(option =>
//option.UseNpgsql(connectionString)); // OPTIONS PATTERN


builder.Services.AddDataProtection();




DIHelper.InjectDbRepositories(builder.Services);
DIHelper.InjectServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CORSPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
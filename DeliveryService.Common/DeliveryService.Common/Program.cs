using DeliveryService.Common.Deliver;
using DeliveryService.Common.Delivery;
using DeliveryService.Common.RequestResponseMaps;
using DeliveryService.Data.DataAccess;
using DeliveryService.Data.Repository;
using Microsoft.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ISQLDataAccess, SQLDataAccess>();
builder.Services.AddTransient<IRequestRepository, RequestRepository>();
builder.Services.AddTransient<IResponseRepository, ResponseRepository>();
builder.Services.AddTransient<IDeliver, Deliver>();
builder.Services.AddTransient<IMapper, PorterMapper>();
builder.Services.AddTransient<IMapper, ShipRocketMapper>();
builder.Services.AddControllers();

//// Database context DI
//var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
//var dbName = Environment.GetEnvironmentVariable("DB_NAME");
//var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
//var dbConnectionString = $"Data Source= {dbHost};Initial Catalog={dbName};User Id=SA;Password={dbPassword}";
////builder.Services.AddDbContext<CommonDbContext>((context) => context.UseSqlServer(dbC));
//builder.Services.AddSingleton<IDbConnection>((sp) => new SqlConnection(dbConnectionString));

// Database context DI (modified due to error: Internal server error occured at CommonAPI: The ConnectionString property has not been initialized.)
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");

if (string.IsNullOrEmpty(dbHost) || string.IsNullOrEmpty(dbName) || string.IsNullOrEmpty(dbPassword))
{
    throw new ApplicationException("Database environment variables are not set.");
}


//var dbConnectionString = "Data Source=192.168.167.171,1434;User ID=sa;Password=Password@123;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
//var dbConnectionString = "Data Source=localhost,1434;User ID=sa;Password=Password@123;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
//var dbConnectionString = "Data Source=localhost,1434;User ID=sa;Password=Password@123;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
var dbConnectionString = $"Data Source=192.168.68.171,1434;Initial Catalog=DeliveryCommon_DB;User ID=sa;Password=Password@123;Trust Server Certificate=True";
//var dbConnectionString = $"Data Source={dbHost};Initial Catalog={dbName};User Id=sa;Password={dbPassword}";
//var dbConnectionString = $"Data Source=localhost,1434;Initial Catalog={dbName};User Id=sa;Password={dbPassword}";
builder.Services.AddSingleton<IDbConnection>((sp) => new SqlConnection(dbConnectionString));

// Add named connection string to configuration
var config = builder.Services.BuildServiceProvider().GetService<IConfiguration>();
config["ConnectionStrings:SqlServerConnection_CommonDb"] = dbConnectionString;



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

app.UseAuthorization();

app.MapControllers();

app.Run();
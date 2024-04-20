using AfriCar_AfriCarAPI;
using AfriCar_AfriCarAPI.Data;
using AfriCar_AfriCarAPI.Repository;
using AfriCar_AfriCarAPI.Repository.IRepository;
using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
	option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarNumberRepository, CarNumberRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddAutoMapper(typeof(MappingConfig));

builder.Services.AddControllers(option =>
{
	//option.ReturnHttpNotAcceptable = true;  //prevent the return type from being anything other than JSON
	option.CacheProfiles.Add("Default30",
		new CacheProfile()
		{
			Duration = 30
		});
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();  //Adding support for xml data format
																  // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var apiVersioningBuilder = builder.Services.AddApiVersioning(options =>
{
	options.AssumeDefaultVersionWhenUnspecified = true;
	options.DefaultApiVersion = new ApiVersion(1, 0);
	options.ReportApiVersions = true;
});

apiVersioningBuilder.AddApiExplorer(options =>
{
	options.GroupNameFormat = "'v'VVV";
	options.SubstituteApiVersionInUrl = true;
});


builder.Services.AddAuthentication(x =>
{
	x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
	x.RequireHttpsMetadata = false;
	x.SaveToken = true;
	x.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
		ValidateIssuer = false,
		ValidateAudience = false,
	};
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Description =
		"JWT Authorization header using the Bearer scheme. \r\n\r\n " +
		"Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
		"Example: \"Bearer 12345abcdef\"",
		Name = "Authorization",
		In = ParameterLocation.Header,
		Scheme = "Bearer"
	});
	options.AddSecurityRequirement(new OpenApiSecurityRequirement()
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							},
				Scheme = "oauth2",
				Name = "Bearer",
				In = ParameterLocation.Header
			},
			new List<string>()
		}
	});
	options.SwaggerDoc("v1", new OpenApiInfo
	{
		Version = "v1.0",
		Title = "AfriCar Rentals v1",
		Description = "API to manage car rentals",
		TermsOfService = new Uri("https://example.com/terms"),
		Contact = new OpenApiContact
		{
			Name = "Itu",
			Url = new Uri("https://github.com/ItumelengKekana")
		},
		License = new OpenApiLicense
		{
			Name = "Example License",
			Url = new Uri("https://example.com/license")
		}
	});
	options.SwaggerDoc("v2", new OpenApiInfo
	{
		Version = "v2.0",
		Title = "AfriCar Rentals v2",
		Description = "API to manage car rentals",
		TermsOfService = new Uri("https://example.com/terms"),
		Contact = new OpenApiContact
		{
			Name = "Itu",
			Url = new Uri("https://github.com/ItumelengKekana")
		},
		License = new OpenApiLicense
		{
			Name = "Example License",
			Url = new Uri("https://example.com/license")
		}
	});
});

builder.Services.AddResponseCaching();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(options =>
	{
		options.SwaggerEndpoint("/swagger/v1/swagger.json", "AfriCar_Rentals_V1");
		options.SwaggerEndpoint("/swagger/v2/swagger.json", "AfriCar_Rentals_V2");
	});
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

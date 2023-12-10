using TimeTable.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthorization();
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureRepositoryManager();

builder.Services.ConfigureSqlContext(builder.Configuration);

//builder.Services.AddAutoMapper(typeof(Program));



builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.AddJwtConfiguration(builder.Configuration);
//builder.Services.ConfigureSwagger();


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.ConfigureAuthService();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}


System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization(); ;

app.MapControllers();

app.Run();

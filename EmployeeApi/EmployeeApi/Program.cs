var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<EmployeeApi.Services.EmployeeService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/*app.UseCors(builder => builder
	.WithOrigins("http://localhost:4200")
	.AllowAnyMethod()
	.AllowAnyHeader());*/

// Add CORS policy
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowFrontend",
		policy => policy
			.WithOrigins("http://localhost:4200") // Angular URL
			.AllowAnyHeader()
			.AllowAnyMethod());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Use CORS policy
app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

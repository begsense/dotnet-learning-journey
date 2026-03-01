using Amazon;
using Amazon.S3;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDefaultAWSOptions(new Amazon.Extensions.NETCore.Setup.AWSOptions
{
    Region = RegionEndpoint.GetBySystemName(
        builder.Configuration["AWS:Region"]
    ),
    Credentials = new Amazon.Runtime.BasicAWSCredentials(
        builder.Configuration["AWS:AccessKey"],
        builder.Configuration["AWS:SecretKey"]
    )
});
builder.Services.AddAWSService<IAmazonS3>();

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

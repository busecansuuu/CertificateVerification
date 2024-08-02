using CertificateVerificationAPI.Context;
using CertificateVerificationAPI.DataAccess.Abstract;
using CertificateVerificationAPI.DataAccess.Concrete;
using CertificateVerificationAPI.Entities;
using CertificateVerificationAPI.Mapping;
using CertificateVerificationAPI.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CertificateDbContext>();
builder.Services.AddScoped<ICertificateRepository,CertificateRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICertificateHolderCompanyRepository, CertificateHolderCompanyRepository>();

builder.Services.AddAutoMapper(typeof(APIMapping));
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<PasswordService>();

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

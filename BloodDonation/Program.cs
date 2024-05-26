using BloodDonation.Application.Commands.CreateDonor;
using BloodDonation.Application.Queries.GetAllDonors;
using BloodDonation.Application.Queries.GetDonorById;
using BloodDonation.Application.ViewModels;
using BloodDonation.Core.Repositories;
using BloodDonation.Infrastructure.Persistence;
using BloodDonation.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("BloodDonationCs");  // BloodDonationCs est� declarado no appsettings.json
builder.Services.AddDbContext<BloodDonationDbContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddScoped<IDonorRepository, DonorRepository>();   // padr�o repository
builder.Services.AddScoped<IBloodStockRepository, BloodStockRepository>();   // padr�o repository


builder.Services.AddControllers();

builder.Services.AddScoped<IRequestHandler<CreateDonorCommand, int>, CreateDonorCommandHandler>();
builder.Services.AddScoped<IRequestHandler<GetAllDonorsQuery, List<DonorViewModel>>, GetAllDonorsQueryHandler>();
builder.Services.AddScoped<IRequestHandler<GetDonorByIdQuery, DonorDetailsViewModel>, GetDonorByIdQueryHandler>();

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

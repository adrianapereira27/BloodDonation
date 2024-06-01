using BloodDonation.Application.Commands.CreateAddress;
using BloodDonation.Application.Commands.CreateDonor;
using BloodDonation.Application.Queries.GetAddressById;
using BloodDonation.Application.Queries.GetAllDonors;
using BloodDonation.Application.Queries.GetDonorById;
using BloodDonation.Application.ViewModels;
using BloodDonation.Core.Repositories;
using BloodDonation.Infrastructure.Persistence;
using BloodDonation.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("BloodDonationCs");  // BloodDonationCs está declarado no appsettings.json
builder.Services.AddDbContext<BloodDonationDbContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddScoped<IDonorRepository, DonorRepository>();   // padrão repository
builder.Services.AddScoped<IAddressRepository, AddressRepository>();   // padrão repository
builder.Services.AddScoped<IBloodStockRepository, BloodStockRepository>();   // padrão repository


builder.Services.AddControllers();

builder.Services.AddScoped<IRequestHandler<CreateDonorCommand, int>, CreateDonorCommandHandler>();
builder.Services.AddScoped<IRequestHandler<CreateAddressCommand, int>, CreateAddressCommandHandler>();
builder.Services.AddScoped<IRequestHandler<GetAllDonorsQuery, List<DonorViewModel>>, GetAllDonorsQueryHandler>();
builder.Services.AddScoped<IRequestHandler<GetDonorByIdQuery, DonorDetailsViewModel>, GetDonorByIdQueryHandler>();
builder.Services.AddScoped<IRequestHandler<GetAddressByIdQuery, AddressDetailsViewModel>, GetAddressByIdQueryHandler>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});

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

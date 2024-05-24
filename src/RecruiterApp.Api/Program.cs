using RecruiterApp.Application.CreateCandidate;
using RecruiterApp.Application.DeleteCandidate;
using RecruiterApp.Application.GetCandidate;
using RecruiterApp.Application.GetCandidatesList;
using RecruiterApp.Application.UpdateCandidate;
using RecruiterApp.Domain.Interfaces;
using RecruiterApp.Infrastructure.Contexts;
using RecruiterApp.Infrastructure.Repositories;
using AutoMapper;
using RecruiterApp.Api.AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<RecruiterAppContext>(options =>
    options.UseSqlServer(connectionString));

// Register the services
builder.Services.AddScoped<ICreateCandidateService, CreateCandidateService>();
builder.Services.AddScoped<IDeleteCandidateService, DeleteCandidateService>();
builder.Services.AddScoped<IGetCandidateService, GetCandidateService>();
builder.Services.AddScoped<IGetCandidatesListService, GetCandidatesListService>();
builder.Services.AddScoped<IUpdateCandidateService, UpdateCandidateService>();

// Register the repository
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddScoped<ICandidateExperienceRepository, CandidateExperienceRepository>();

// Register AutoMapper
IMapper mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var contex = scope.ServiceProvider.GetRequiredService<RecruiterAppContext>();
    contex.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Candidates}/{action=Index}/{id?}");

app.Run();

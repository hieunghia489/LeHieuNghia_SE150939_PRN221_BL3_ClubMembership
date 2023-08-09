using ClubMembership_Repositories.Interfaces;
using ClubMembership_Repositories.Repositories;
using ClubMembership_Services.Interfaces;
using ClubMembership_Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IMajorService,MajorService>();
builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IMajorRepo, MajorRepo>();
builder.Services.AddScoped<IGradeRepo, GradeRepo>();
builder.Services.AddScoped<IStudentRepo, StudentRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

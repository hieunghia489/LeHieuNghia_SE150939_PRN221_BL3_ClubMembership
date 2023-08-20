using ClubMembership_Repositories.IRepositories;
using ClubMembership_Repositories.Repositories;
using ClubMembership_Services.IServices;
using ClubMembership_Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IMajorService,MajorService>();
builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IClubService, ClubService>();
builder.Services.AddScoped<IClubActivityService, ClubActivityService>();
builder.Services.AddScoped<IMembershipService, MembershipService>();
builder.Services.AddScoped<IClubBoardService, ClubBoardService>();
builder.Services.AddScoped<IGroupMemberService, GroupMemberService>();
builder.Services.AddScoped<IParticipantService, ParticipantService>();

builder.Services.AddScoped<IMajorRepo, MajorRepo>();
builder.Services.AddScoped<IGradeRepo, GradeRepo>();
builder.Services.AddScoped<IStudentRepo, StudentRepo>();
builder.Services.AddScoped<IClubRepo, ClubRepo>();
builder.Services.AddScoped<IClubActivityRepo, ClubActivityRepo>();
builder.Services.AddScoped<IMembershipRepo, MembershipRepo>();
builder.Services.AddScoped<IClubBoardRepo, ClubBoardRepo>();
builder.Services.AddScoped<IGroupMemberRepo, GroupMemberRepo>();
builder.Services.AddScoped<IParticipantRepo, ParticipantRepo>();
builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

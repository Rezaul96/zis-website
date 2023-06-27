using Domain.UnitOfWork;
using Infrastructure;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Scorerecord.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Infrastructure.Shared;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using Scorerecord.Helper;
using Scorerecord;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IEventObjectService, EventObjectService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IIndustryService, IndustryService>();
builder.Services.AddScoped<IObjectTypeService, ObjectTypeService>();
builder.Services.AddScoped<IRegionService, RegionService>();
builder.Services.AddScoped<ISequenceService, SequenceService>();
builder.Services.AddScoped<ITeamMemberService, TeamMemberService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<ISequenceObjectService, SequenceObjectService>();
builder.Services.AddScoped<IEventSequenceObjectService, EventSequenceObjectService>();
builder.Services.AddScoped<IEventShareService, EventShareService>();
// Add services to the container.
ServiceRegistration.AddSharedInfrastructure(builder.Services, builder.Configuration);
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
builder.Services.AddRazorPages();
builder.Services.AddSignalR();

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.Configure<MvcViewOptions>(options =>
options.HtmlHelperOptions.CheckBoxHiddenInputRenderMode =
CheckBoxHiddenInputRenderMode.None);
builder.Services.AddSingleton<IFileProvider>(
 new PhysicalFileProvider(
     Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(options =>
{
    options.LoginPath = "/Admin";
});
var app = builder.Build();
WebHostHelper.Configure(builder.Environment);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
           name: "areas",
           pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
         );
        endpoints.MapAreaControllerRoute(
            name: "default",
            areaName: "Website",
            pattern: "{controller=Home}/{action=Index}"
        );
    });
app.Run();

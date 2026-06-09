using ComplaintSystem.Data;
using ComplaintSystem.Hubs;
using ComplaintSystem.Middleware;
using ComplaintSystem.Models;
using ComplaintSystem.Reposatory.Implementation;
using ComplaintSystem.Reposatory.Interface;
using ComplaintSystem.Service.Implementation;
using ComplaintSystem.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ── MVC ───────────────────────────────────────────────────────────────────
builder.Services.AddControllersWithViews();

// ── SQL Server ────────────────────────────────────────────────────────────
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// ── ASP.NET Identity ──────────────────────────────────────────────────────
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

// ── Session ───────────────────────────────────────────────────────────────
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

// ── SignalR ───────────────────────────────────────────────────────────────
builder.Services.AddSignalR();

// ── HTTP Context ──────────────────────────────────────────────────────────
builder.Services.AddHttpContextAccessor();

// ── Repository & Services (Dependency Injection) ──────────────────────────
//
//   Architecture layers:
//
//   Controller  →  Service  →  Repository  →  DbContext
//
//   • Repository: pure DB access, returns entities
//   • Service:    business logic, returns ViewModels / result tuples
//   • Controller: thin orchestrator, sets TempData, calls View/Redirect
//

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IComplaintService, ComplaintService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IUserService, UserService>();

// ════════════════════════════════════════════════════════════════════════════
var app = builder.Build();
// ════════════════════════════════════════════════════════════════════════════

// ── Seed ──────────────────────────────────────────────────────────────────
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
    DbInitializer.Seed(db);
    await DbInitializer.SeedAdminAsync(scope.ServiceProvider);
}

// ── HTTP Pipeline (ORDER MATTERS) ─────────────────────────────────────────
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseSession();           // ← must be BEFORE UseAuthorization
app.UseAuthorization();

app.UseRequestLogging();    // custom middleware — logs method/path/status/ms

// ── Endpoints ─────────────────────────────────────────────────────────────
app.MapHub<ChatHub>("/chatHub");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
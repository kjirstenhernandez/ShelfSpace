

using ShelfSpace.Services;
using ShelfSpace.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

var dbconnectionstring = builder.Configuration.GetConnectionString("ShelfSpaceContext");
Console.Write(dbconnectionstring);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// This is for Basic Authentication
// builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null)

var _authkey=builder.Configuration.GetValue<string>("JwtSettings:securitykey");
builder.Services.AddAuthentication(item => {
    item.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme; 
    item.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(item=>{
    item.RequireHttpsMetadata=true;
    item.SaveToken=true;
    item.TokenValidationParameters=new TokenValidationParameters(){
        ValidateIssuerSigningKey=true,
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authkey)),
        ValidateIssuer=false,
        ValidateAudience=false,
    };
});

builder.Services.AddDbContext<ShelfSpaceContext>(options =>
        options.UseSqlite(dbconnectionstring));

var _jwtSettings=builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(_jwtSettings);

builder.Services.AddHttpClient();
builder.Services.AddSingleton<UserState>();
builder.Services.AddSingleton<TestAppData>();
builder.Services.AddBlazoredLocalStorage();



builder.Services.AddScoped<MediaState>();
builder.Services.AddScoped<UserState>();
builder.Services.AddSingleton<IPasswordService, PasswordService>();



var app = builder.Build();

    //Testing the Database Connection
    try
    {
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ShelfSpaceContext>();
            
            // Testing the connection:
            await dbContext.Database.CanConnectAsync();
            Console.WriteLine("Database connection successful.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database connection failed: {ex.Message}");
    }



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Media}/{action=Index}/{id?}");

app.UseHttpsRedirection();

app.UseStaticFiles();


app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

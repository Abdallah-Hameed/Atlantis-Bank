using Atlantis_Bank_API.Authorization;
using AtlantisBank.BLL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = "AtlantisBankApi",
            ValidAudience = "AtlantisBankClients",

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("THIS_IS_A_VERY_SECRET_KEY_FOR_ATLANTIS_BANK_123456")),

            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddSingleton<IAuthorizationHandler, clsPermissionHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, clsUserUpdateHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, clsUserAddHandler>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Client_View", p => p.Requirements.Add(new clsPermissionRequirement("Client_View")));
    options.AddPolicy("Client_Add", p => p.Requirements.Add(new clsPermissionRequirement("Client_Add")));
    options.AddPolicy("Client_Edit", p => p.Requirements.Add(new clsPermissionRequirement("Client_Edit")));
    options.AddPolicy("Client_Delete", p => p.Requirements.Add(new clsPermissionRequirement("Client_Delete")));

    options.AddPolicy("Employee_View", p => p.Requirements.Add(new clsPermissionRequirement("Employee_View")));
    options.AddPolicy("Employee_Add", p => p.Requirements.Add(new clsPermissionRequirement("Employee_Add")));
    options.AddPolicy("Employee_Edit", p => p.Requirements.Add(new clsPermissionRequirement("Employee_Edit")));
    options.AddPolicy("Employee_Delete", p => p.Requirements.Add(new clsPermissionRequirement("Employee_Delete")));

    options.AddPolicy("User_View", p => p.Requirements.Add(new clsPermissionRequirement("User_View")));
    options.AddPolicy("User_Add", p => p.Requirements.Add(new clsPermissionRequirement("User_Add")));
    options.AddPolicy("User_Edit", p => p.Requirements.Add(new clsPermissionRequirement("User_Edit")));
    options.AddPolicy("User_Delete", p => p.Requirements.Add(new clsPermissionRequirement("User_Delete")));
    options.AddPolicy("User_ChangePassword", p => p.Requirements.Add(new clsPermissionRequirement("User_ChangePassword")));

    options.AddPolicy("Account_View", p => p.Requirements.Add(new clsPermissionRequirement("Account_View")));
    options.AddPolicy("Account_Add", p => p.Requirements.Add(new clsPermissionRequirement("Account_Add")));
    options.AddPolicy("Account_Edit", p => p.Requirements.Add(new clsPermissionRequirement("Account_Edit")));
    options.AddPolicy("Account_Delete", p => p.Requirements.Add(new clsPermissionRequirement("Account_Delete")));

    options.AddPolicy("Deposit", p => p.Requirements.Add(new clsPermissionRequirement("Deposit")));
    options.AddPolicy("Withdrawal", p => p.Requirements.Add(new clsPermissionRequirement("Withdrawal")));
    options.AddPolicy("Transfer", p => p.Requirements.Add(new clsPermissionRequirement("Transfer")));
    options.AddPolicy("Transaction_View", p => p.Requirements.Add(new clsPermissionRequirement("Transaction_View")));

    options.AddPolicy("User_EditOrSelf", p => p.Requirements.Add(
        new OperationAuthorizationRequirement { Name = "User_Update" }));

    options.AddPolicy("User_AddPolicy", p => p.Requirements.Add(
        new OperationAuthorizationRequirement { Name = "User_Add" }));
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter: Bearer {your JWT token}"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();

app.Use(async (context, next) =>
{
    if (context.User.Identity?.IsAuthenticated == true)
    {
        var userIdClaim = context.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (int.TryParse(userIdClaim, out int userId))
        {
            clsCurrentUser.CurrentUser = clsUser.Find(userId);

            var permissions = context.User
                .FindAll("Permission")
                .Select(c => c.Value)
                .ToHashSet();

            clsCurrentUser.Permissions = permissions;

            var positionPermissions = context.User
                .FindAll("PositionPermission")
                .Select(c => c.Value)
                .ToHashSet();

            clsCurrentUser.PositionPermissions = positionPermissions;
        }
    }

    await next();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
using Microsoft.EntityFrameworkCore;
using gestao_campeonato.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using gestao_campeonato.Controllers;
using gestao_campeonato.Service;
using gestao_campeonato.Repository;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//AddIdentity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<MyDbContext>()
    .AddDefaultTokenProviders();
//AddAuthentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
//AddJwtBearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

/*builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
});*/
builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
);

var connectionStringMysql = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddMvc();
builder.Services.AddDbContext<MyDbContext>(options => options.UseMySql(
    connectionStringMysql,
    ServerVersion.AutoDetect(connectionStringMysql)
));

builder.Services.AddScoped<ICarroRepository, CarroRepository>();
builder.Services.AddScoped<ICarroService, CarroService>();
builder.Services.AddScoped<IEquipeRepository, EquipeRepository>();
builder.Services.AddScoped<IEquipeService, EquipeService>();
builder.Services.AddScoped<ILocal_CampeonatoRepository, Local_CampeonatoRepository>();
builder.Services.AddScoped<ILocal_CampeonatoService, Local_CampeonatoService>();
builder.Services.AddScoped<IPartidaRepository, PartidaRepository>();
builder.Services.AddScoped<IPartidaService, PartidaService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IClassificacaoRepository, ClassificacaoRepository>();
builder.Services.AddScoped<IClassificacaoService, ClassificacaoService>();
builder.Services.AddScoped<ICampeonatoRepository, CampeonatoRepository>();
builder.Services.AddScoped<ICampeonatoService, CampeonatoService>();

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles(); 

app.MapControllers();

app.Run();



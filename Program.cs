using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using jasguarApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var Key = builder.Configuration["jwt:signedKey"];

builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer(opt => {
    var signingKey = new SymmetricSecurityKey( Encoding.UTF8.GetBytes(Key?? "NULL"));
    var signonCredentials = new SigningCredentials(signingKey, 
                                SecurityAlgorithms.HmacSha256Signature);
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = signingKey,
    };
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var ConnectionString = builder.Configuration.GetConnectionString("jasguarConnectionString");
builder.Services.AddDbContext<JasguarContext>(options => options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString)));
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/auth", (string user, string password) =>
{
    var byteKey = Encoding.UTF8.GetBytes(Key?? "NULL");
    var tokenHandler = new JwtSecurityTokenHandler();
    var tokenDes = new SecurityTokenDescriptor()
    {
        Subject = new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Name, user),
            new Claim(ClaimTypes.Role, "Mascota")
        }),
        Expires = DateTime.UtcNow.AddMonths(1),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(byteKey),
                                                        SecurityAlgorithms.HmacSha256Signature)
    };

    var token = tokenHandler.CreateToken(tokenDes);

    return tokenHandler.WriteToken(token);
});


app.UseHttpsRedirection();

app.MapControllers();

app.Run();


// eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEyNGZzZGZzZGYiLCJuYmYiOjE3MjIxNDUyNTgsImV4cCI6MTcyNDgyMzY1OCwiaWF0IjoxNzIyMTQ1MjU4fQ.FpDMdW-6mkEEA6XDFCq_cJ9-NlMSNu-4W1L8sbfUSLQ



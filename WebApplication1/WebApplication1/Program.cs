using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

//PACKAGES:
//Microsoft.AspNetCore.OpenApi
//Swashbuckle.AspNetCore
//Microsoft.EntityFrameworkCore
//Microsoft.EntityFrameworkCore.SqlServer
//Microsoft.EntityFrameworkCore.Design

//KOMENDY:

// dotnet new tool-manifest
//
// dotnet tool install dotnet-ef --version 8.0.0
//
//     <InvariantGlobalization>false</InvariantGlobalization>
//
// Tworzenie modeli:
// dotnet ef dbcontext scaffold "Data Source=localhost;Initial Catalog=APBD;User ID=sa;Password=asd123POKo223;Encrypt=False" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context-dir Context

// dotnet ef dbcontext scaffold "Data Source=db-mssql;InitialCatalog=2019SBD;Integrated Security=True;Encrypt=False" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context-dir Context
// in appsettings.json connection string:
//"Pjatk": "Data Source=db-mssql;InitialCatalog=2019SBD;Integrated Security=True;Encrypt=False"

//////////////

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


//NNNNNNNEEEEEE
builder.Services.AddDbContext<HospitalDbContext>(opt =>
{
    string connString = builder.Configuration.GetConnectionString("Pjatk");
    opt.UseSqlServer(connString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

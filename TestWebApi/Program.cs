using Application;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text;
using WebApi;
using WebApi.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddWebApiServices(builder.Configuration);

//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
//    {
//        Version = "v1",
//        Title = $"{System.Reflection.Assembly.GetEntryAssembly().GetName().Name}"
//    });
  
//});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TemplateKingICT");
    c.DocExpansion(DocExpansion.None);
    c.EnableFilter();
});

app.UseCors("_myAllowSpecificOrigins");
app.MapControllers();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "api/{controller}/{action}");
app.UseHttpsRedirection();  
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors(
      options => options
          .AllowAnyHeader()
          .WithMethods("OPTIONS", "GET", "POST", "PUT", "DELETE")
          .AllowAnyOrigin()
        );


app.Run();

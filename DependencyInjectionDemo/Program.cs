using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using DependencyInjectionDemo.Logic;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

/**
 * AddTransient = Create new instance everytime
 *                Gets cleared by the garbage collector
 *                
 * AddSingleton = One instance created
 *                Normally used for configs
 *                Clogs memory because it is only cleared when server stops
 *                
 * AddScoped = One instance per request per person
 * **/
//builder.Services.AddScoped<IDemoLogic, DemoLogic>();
builder.Services.AddTransient<IDemoLogic, BetterDemoLogic>();
builder.Host.UseSerilog((context, config) =>
{
    config.WriteTo.Console();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

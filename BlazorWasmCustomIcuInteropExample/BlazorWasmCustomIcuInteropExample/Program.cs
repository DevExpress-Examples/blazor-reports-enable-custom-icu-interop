using BlazorWasmCustomIcuInteropExample.Components;
using DevExpress.Blazor;
using DevExpress.Blazor.Reporting;
using _Imports = BlazorWasmCustomIcuInteropExample.Client._Imports;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddControllers();
builder.Services.AddDevExpressBlazor(options =>
{
    options.SizeMode = SizeMode.Small;
});
builder.Services.AddDevExpressBlazorReporting();
builder.Services.AddDevExpressServerSideBlazorReportViewer();

builder.Services.AddHttpClient();

builder.Services.AddMvc();

var app = builder.Build();

if(app.Environment.IsDevelopment()) {
    app.UseWebAssemblyDebugging();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(_Imports).Assembly)
    .AllowAnonymous();
app.MapControllers();

app.Run();
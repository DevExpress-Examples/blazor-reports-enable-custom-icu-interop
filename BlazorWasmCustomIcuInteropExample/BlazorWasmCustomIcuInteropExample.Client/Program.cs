using DevExpress.Drawing.Internal.Fonts.Interop;
using BlazorWasmCustomIcuInteropExample.Client.Native;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddDevExpressBlazor(options => {
    options.SizeMode = DevExpress.Blazor.SizeMode.Medium;
});
builder.Services.AddDevExpressWebAssemblyBlazorReportViewer();

builder.Services.AddHttpClient("local", c => {
    c.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});
ICUInterop.CustomICUInterop = new IcuInterop();

await builder.Build().RunAsync();
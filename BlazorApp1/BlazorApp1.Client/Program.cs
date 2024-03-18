using BlazorApp1.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorApp1.Client
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);

			builder.Services.AddScoped(sp => new HttpClient());
			builder.Services.AddScoped<ProductSevice>();

			await builder.Build().RunAsync();
		}
	}
}

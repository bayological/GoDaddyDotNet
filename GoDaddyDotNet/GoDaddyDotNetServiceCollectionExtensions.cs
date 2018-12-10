using GoDaddyDotNet;
using Microsoft.Extensions.Configuration;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
	///<summary>GoDaddyDotNet extensions for <see cref="IServiceCollection"/>.</summary>
	public static class GoDaddyDotNetServiceCollectionExtensions
	{

		/// <summary>Adds services required for GoDaddyDotNet.</summary>
		/// <param name="serviceCollection">The <see cref="IServiceCollection"/>.</param> 
		public static IServiceCollection AddGoDaddyDotNet(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddOptions();
			services.Configure<GoDaddySettings>(configuration.GetSection("GoDaddySettings"));
			services.AddSingleton<IGoDaddyClient, GoDaddyClient>();

			return services;
		}
	}
}

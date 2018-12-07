using GoDaddyDotNet.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace GoDaddyDotNet.IntegrationTests
{
	[TestClass]
	public class GoDaddyClientTests
	{
		private IGoDaddyClient _testee;

		[TestInitialize]
		public void Init()
		{
			var config = new ConfigurationBuilder().AddEnvironmentVariables();
			GoDaddySettings settings = new GoDaddySettings()
			{
				ApiUrl = Environment.GetEnvironmentVariable("GoDaddySettings_ApiUrl"),
				ApiKey = Environment.GetEnvironmentVariable("GoDaddySettings_ApiKey"),
				ApiSecret = Environment.GetEnvironmentVariable("GoDaddySettings_ApiSecret")
			};
			IOptions<GoDaddySettings> options = Options.Create(settings);
			_testee = new GoDaddyClient(options);
		}

		[TestMethod]
		public async Task CheckDomain_ShouldReturnFalse()
		{
			var result = await _testee.CheckDomainAsync("bayological.io").ConfigureAwait(false);
			Assert.IsFalse(result.Available);
		}
	}
}

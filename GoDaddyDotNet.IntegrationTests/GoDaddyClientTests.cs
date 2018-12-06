using GoDaddyDotNet.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
			var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
			GoDaddySettings settings = new GoDaddySettings()
			{
				ApiUrl = config["GoDaddySettings:ApiUrl"],
				ApiKey = config["GoDaddySettings:ApiKey"],
				ApiSecret = config["GoDaddySettings:ApiSecret"]
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

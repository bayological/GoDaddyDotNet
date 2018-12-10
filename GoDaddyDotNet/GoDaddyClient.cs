using GoDaddyDotNet.Responses;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GoDaddyDotNet
{

	public class GoDaddyClient : IGoDaddyClient
	{
		private HttpClient _client { get { return GetHttpClient(); } }
		private readonly GoDaddySettings _settings;

		public GoDaddyClient(IOptions<GoDaddySettings> settings)
		{
			_settings = settings.Value;
		}

		public async Task<CheckDomainResponse> CheckDomainAsync(string domainName)
		{
			var response = new CheckDomainResponse(); 
			var request = GetRequest($"domains/available?domain={domainName}&checkType=full", HttpMethod.Get); 
			var result = await _client.SendAsync(request).ConfigureAwait(false);

			if (result.IsSuccessStatusCode)
			{
				var rawData = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
				response = JsonConvert.DeserializeObject<CheckDomainResponse>(rawData);
				response.Price = response.Price / 1000000;
			}

			return response;
		}

		private HttpClient GetHttpClient()
		{
			var client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			return client;
		}

		private HttpRequestMessage GetRequest(string endpoint, HttpMethod httpMethod, bool authenticate = true)
		{
			var request = new HttpRequestMessage()
			{
				RequestUri = new Uri(_settings.ApiUrl + endpoint),
				Method = httpMethod
			}; 

			if (authenticate)
			{
				request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				request.Headers.Authorization = new AuthenticationHeaderValue("sso-key", $"{_settings.ApiKey}:{_settings.ApiSecret}");
			}

			return request;
		}

	}
}

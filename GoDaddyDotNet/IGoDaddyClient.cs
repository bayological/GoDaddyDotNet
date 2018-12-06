using GoDaddyDotNet.Responses;
using System.Threading.Tasks;

namespace GoDaddyDotNet
{
	public interface IGoDaddyClient
	{
		/// <summary>
		/// This method will check to see if the specifed domain is available
		/// </summary>
		/// <param name="domainName">The name of the domain to check</param>
		/// <returns></returns>
		Task<CheckDomainResponse> CheckDomainAsync(string domainName);
	}
}

namespace GoDaddyDotNet.Responses
{
	public class CheckDomainResponse
	{
		public bool Available { get; set; }
		public string Domain { get; set; }
		public decimal Price { get; set; }
		public int Period { get; set; }
		public string Currency { get; set; }
	}
}

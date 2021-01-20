namespace Poc.MobileApp.Infra.Http.Services
{
	public class Token
	{
		public bool Authenticated { get { return !string.IsNullOrWhiteSpace(Value); } }
		public string Value { get; set; }
	}
}

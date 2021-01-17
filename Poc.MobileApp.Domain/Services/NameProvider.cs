namespace Poc.MobileApp.Core.Services
{
	public class NameProvider : INameProvider
	{
		private readonly INumberProvider _numberProvider;

		public NameProvider(INumberProvider numberProvider)
		{
			_numberProvider = numberProvider;
		}


		public string Next()
		{
			return $"erlon{_numberProvider.Next()}";
		}
	}
}

using System;

namespace Poc.MobileApp.Core.Services
{
	public class NumberProvider : INumberProvider
	{
		public int Next()
		{
			return new Random().Next(10);
		}
	}
}

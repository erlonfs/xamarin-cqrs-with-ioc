using Poc.MobileApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

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

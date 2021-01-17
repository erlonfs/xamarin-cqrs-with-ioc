using System;

namespace Poc.MobileApp.Domain
{
	public class BusinessException : Exception
	{
		public BusinessException(string message) : base(message)
		{
		}
	}
}

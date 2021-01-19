using System;

namespace Poc.MobileApp.Shared.Common
{
	public class BusinessException : Exception
	{
		public BusinessException(string message) : base(message)
		{
		}
	}
}

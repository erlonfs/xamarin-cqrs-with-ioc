using Poc.MobileApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Poc.MobileApp
{
	public partial class LoginViewModel : ViewModel
	{
		private readonly INumberProvider _numberProvider;

		public string Login { get; set; }

		public LoginViewModel(INumberProvider numberProvider)
		{
			Login = "erlonfs";
			_numberProvider = numberProvider;

			Login = _numberProvider.Next().ToString();
		}
	}
}
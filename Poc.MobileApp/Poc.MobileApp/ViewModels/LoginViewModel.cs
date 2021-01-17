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
		private readonly INameProvider _nameProvider;

		public string Login { get; set; }

		public LoginViewModel(INameProvider nameProvider)
		{
			_nameProvider = nameProvider;

			Login = _nameProvider.Next();
		}
	}
}
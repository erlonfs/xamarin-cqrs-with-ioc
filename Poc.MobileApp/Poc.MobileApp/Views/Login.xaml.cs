using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Poc.MobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login()
		{
			InitializeComponent();

			var viewModel = ServiceLocator.Current.GetInstance<LoginViewModel>();

			BindingContext = viewModel;

		}

		public async Task diplayAlert()
		{
			await DisplayActionSheet("Question?", "Would you like to play a game", "Yes", "No");
		}
	}
}
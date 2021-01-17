using CommonServiceLocator;
using Poc.MobileApp.Core.Services;
using Poc.MobileApp.Views;
using Unity;
using Unity.ServiceLocation;
using Xamarin.Forms;

namespace Poc.MobileApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			var container = new UnityContainer();

			container.RegisterType<INumberProvider, NumberProvider>();
			container.RegisterType<INameProvider, NameProvider>();

			ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));

			MainPage = new Login();

		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}


	}
}

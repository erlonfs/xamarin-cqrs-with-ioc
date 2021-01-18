using Xamarin.Forms;

namespace Poc.MobileApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			new Bootstrapper(this);
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

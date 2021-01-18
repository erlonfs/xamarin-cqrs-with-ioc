using Autofac;
using Poc.MobileApp.ViewModels;
using Poc.MobileApp.ViewModels.Pessoa;
using Poc.MobileApp.Views;
using Poc.MobileApp.Views.Pessoa;
using Xamarin.Forms;

namespace Poc.MobileApp
{
	public class Bootstrapper
	{
		private readonly App _app;

		public Bootstrapper(App app)
		{
			_app = app;

			Run();

		}

		private void Run()
		{
			var builder = new ContainerBuilder();
			ConfigureContainer(builder);

			var container = builder.Build();

			var viewFactory = container.Resolve<IViewFactory>();
			RegisterViews(viewFactory);

			ConfigureApplication(container);
		}

		private void ConfigureApplication(IContainer container)
		{
			var viewFactory = container.Resolve<IViewFactory>();

			var mainPage = viewFactory.Resolve<HomePageViewModel>();
			var navPage = new NavigationPage(mainPage);

			_app.MainPage = navPage;
		}

		private void ConfigureContainer(ContainerBuilder builder)
		{
			builder.RegisterModule<DependenciesModule>();
			builder.RegisterModule<ViewModelModule>();
		}

		private void RegisterViews(IViewFactory viewFactory)
		{
			viewFactory.Register<HomePageViewModel, HomePage>();
			viewFactory.Register<CriarViewModel, Criar>();
			viewFactory.Register<ConsultarViewModel, Consultar>();
		}
	}
}

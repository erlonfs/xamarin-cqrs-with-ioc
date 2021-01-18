using Autofac;
using Poc.MobileApp.ViewModels;
using Poc.MobileApp.ViewModels.Pessoa;
using Poc.MobileApp.Views;
using Poc.MobileApp.Views.Pessoa;

namespace Poc.MobileApp
{
	public class ViewModelModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<HomePage>().SingleInstance();
			builder.RegisterType<HomePageViewModel>().SingleInstance();

			builder.RegisterType<Criar>();
			builder.RegisterType<CriarViewModel>();

			builder.RegisterType<Consultar>();
			builder.RegisterType<ConsultarViewModel>();
		}
	}
}

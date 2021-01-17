using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Poc.MobileApp.Core.Services;
using Poc.MobileApp.Domain;
using Poc.MobileApp.Domain.Commands;
using Poc.MobileApp.Domain.Repositories;
using Poc.MobileApp.Infra.EF;
using Poc.MobileApp.Infra.EF.Repositories.Pessoas;
using Poc.MobileApp.ViewModels.Pessoa;
using Poc.MobileApp.Views.Pessoa;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Poc.MobileApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			var builder = new ContainerBuilder();

			builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();
			builder.RegisterType<NumberProvider>().As<INumberProvider>();
			builder.RegisterType<NameProvider>().As<INameProvider>();
			builder.RegisterType<PessoaRepository>().As<IPessoaRepository>();

			builder.RegisterAssemblyTypes(typeof(CriarViewModel).Assembly).AsSelf();
			builder.RegisterAssemblyTypes(typeof(Pessoa).Assembly).AsClosedTypesOf(typeof(ICommandHandler<>)).AsImplementedInterfaces();

			var dbPath = DependencyService.Get<IDatabaseServicePathProvider>().GetPath();

			var conn = new SqliteConnection(@$"Data Source={dbPath}\\hello.db");

			var options = new DbContextOptionsBuilder<AppDbContext>().UseSqlite(conn).Options;
			builder.RegisterType<AppDbContext>().AsSelf().WithParameter("options", options);

			var container = builder.Build();

			ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));

			try
			{
				MainPage = new Criar();
			}
			catch (BusinessException e)
			{
				MainPage.DisplayAlert("Aviso", e.Message, "Ok");
			}
			catch (Exception e)
			{
				MainPage.DisplayAlert("Ocorreu um erro", e.Message, "Ok");
			}



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

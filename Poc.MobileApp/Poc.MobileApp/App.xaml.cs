using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Poc.MobileApp.Core.Services;
using Poc.MobileApp.Domain;
using Poc.MobileApp.Domain.Commands;
using Poc.MobileApp.Domain.Queries;
using Poc.MobileApp.Domain.Queries.Pessoa;
using Poc.MobileApp.Domain.Repositories;
using Poc.MobileApp.Infra.Dapper;
using Poc.MobileApp.Infra.EF;
using Poc.MobileApp.Infra.EF.Repositories.Pessoas;
using Poc.MobileApp.ViewModels.Pessoa;
using Poc.MobileApp.Views.Pessoa;
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
			builder.RegisterType<QueryExecutor>().As<IQueryExecutor>();
			builder.RegisterType<NumberProvider>().As<INumberProvider>();
			builder.RegisterType<NameProvider>().As<INameProvider>();
			builder.RegisterType<PessoaRepository>().As<IPessoaRepository>();

			builder.RegisterType<CriarViewModel>().AsSelf();
			builder.RegisterType<ConsultarViewModel>().AsSelf();

			builder.RegisterAssemblyTypes(typeof(Qux).Assembly)
							.AsClosedTypesOf(typeof(ICommandHandler<>))
							.AsImplementedInterfaces();

			builder.RegisterAssemblyTypes(typeof(Bar).Assembly)
							.AsClosedTypesOf(typeof(IQueryHandler<,>))
							.AsImplementedInterfaces();

			var dbPath = DependencyService.Get<IDatabaseServicePathProvider>().Get();
			var conn = new SqliteConnection(@$"Data Source={dbPath}\\mobileApp2021.db");

			var options = new DbContextOptionsBuilder<AppDbContext>().UseSqlite(conn).Options;
			builder.RegisterType<AppDbContext>().AsSelf().WithParameter("options", options);
			builder.Register(c => new MobileAppConnection(conn)).As<AppConnection>();

			var container = builder.Build();

			ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));

			MainPage = new Consultar();

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

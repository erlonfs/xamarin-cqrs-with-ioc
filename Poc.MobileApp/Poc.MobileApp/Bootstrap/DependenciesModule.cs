using Autofac;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Poc.MobileApp.Core.Services;
using Poc.MobileApp.Domain;
using Poc.MobileApp.Domain.Repositories;
using Poc.MobileApp.Domain.Services;
using Poc.MobileApp.Infra.Dapper;
using Poc.MobileApp.Infra.EF;
using Poc.MobileApp.Infra.EF.Repositories.Pessoas;
using Poc.MobileApp.Infra.EF.Services;
using Poc.MobileApp.Infra.Http.Services;
using Poc.MobileApp.Shared.Common;
using Poc.MobileApp.Shared.Cqrs;
using Xamarin.Forms;

namespace Poc.MobileApp
{
	public class DependenciesModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();
			builder.RegisterType<QueryExecutor>().As<IQueryExecutor>();
			builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

			builder.RegisterType<SincronizacaoRepository>().As<ISincronizacaoRepository>();
			builder.RegisterType<PessoaRepository>().As<IPessoaRepository>();
			builder.RegisterType<SincronizacaoServidorService>().As<ISincronizacaoServidorService>();
			builder.RegisterType<SincronizacaoClienteService>().As<ISincronizacaoClienteService>();

			builder.RegisterAssemblyTypes(typeof(Qux).Assembly)
							.AsClosedTypesOf(typeof(ICommandHandler<>))
							.AsImplementedInterfaces();

			builder.RegisterAssemblyTypes(typeof(Bar).Assembly)
							.AsClosedTypesOf(typeof(IQueryHandler<,>))
							.AsImplementedInterfaces();

			var dbPath = DependencyService.Get<IDatabaseServicePathProvider>().Get();
			var conn = new SqliteConnection(@$"Data Source={dbPath}\\mobileApp2021.db");

			var options = new DbContextOptionsBuilder<AppDbContext>().UseSqlite(conn).Options;
			builder.RegisterType<AppDbContext>().AsSelf().WithParameter("options", options).InstancePerLifetimeScope();
			builder.Register(c => new MobileAppConnection(conn)).As<AppConnection>();

			builder.RegisterType<ViewFactory>().As<IViewFactory>().SingleInstance();
			builder.RegisterType<Navigator>().As<INavigator>().SingleInstance();
			builder.Register(context => App.Current.MainPage.Navigation).SingleInstance();
		}
	}
}

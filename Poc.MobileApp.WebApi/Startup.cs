using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Poc.MobileApp.Infra.EF;
using Poc.MobileApp.Shared.Common;
using Microsoft.EntityFrameworkCore;
using Poc.MobileApp.WebApi.Controllers;
using Poc.MobileApp.Shared.Cqrs;
using Poc.MobileApp.Infra.EF.Repositories.Pessoas;
using Poc.MobileApp.Domain.Repositories;
using Poc.MobileApp.Domain;
using Poc.MobileApp.Infra.Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Poc.MobileApp.WebApi
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		public IContainer Container { get; private set; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public virtual void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc(x =>
			{
				x.EnableEndpointRouting = false;

			}).AddControllersAsServices();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API", Version = "v1" });
			});

			services.AddDbContext<AppDbContext>(options =>
			{
				options.UseSqlServer(new SqlConnectionStringBuilder
				{
					DataSource = @"(LocalDB)\MSSQLLocalDB",
					InitialCatalog = "mobileApp2021",
					IntegratedSecurity = true
				}.ConnectionString);
				options.UseLazyLoadingProxies();
				options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
			});

			var builder = new ContainerBuilder();

			builder.Populate(services);

			ConfigureContainer(builder);

			Container = builder.Build();

		}

		public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();
			 
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", $"Poc MobileApp V1 {env.EnvironmentName}");
			});
		}

		public void ConfigureContainer(ContainerBuilder builder)
		{
			builder.RegisterType<PessoaController>().PropertiesAutowired();
			builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();
			builder.RegisterType<QueryExecutor>().As<IQueryExecutor>();
			builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

			builder.RegisterType<PessoaRepository>().As<IPessoaRepository>();

			builder.RegisterAssemblyTypes(typeof(Qux).Assembly)
							.AsClosedTypesOf(typeof(ICommandHandler<>))
							.AsImplementedInterfaces();

			builder.RegisterAssemblyTypes(typeof(Bar).Assembly)
							.AsClosedTypesOf(typeof(IQueryHandler<,>))
							.AsImplementedInterfaces();

			var cnn = new SqlConnectionStringBuilder
			{
				DataSource = @"(LocalDB)\MSSQLLocalDB",
				InitialCatalog = "mobileApp2021",
				IntegratedSecurity = true
			}.ConnectionString;

			var conn = new SqlConnection(cnn);

			builder.Register(c => new WebApiAppConnection(conn)).As<AppConnection>().SingleInstance();


		}
	}
}

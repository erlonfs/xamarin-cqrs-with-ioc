using Poc.MobileApp.Domain.Queries.Pessoa;
using Poc.MobileApp.Shared.Cqrs;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Poc.MobileApp.ViewModels.Pessoa
{
	public partial class ConsultarViewModel : BaseViewModel
	{
		private readonly IQueryExecutor _queryExecutor;
		private readonly INavigator _navigator;

		public ObservableCollection<ConsultaDto> Pessoas { get; set; } = new ObservableCollection<ConsultaDto>();

		public ConsultarViewModel(IQueryExecutor queryExecutor, INavigator navigator)
		{
			_queryExecutor = queryExecutor;
			_navigator = navigator;

			Consultar.Execute(null);
		}

		public Command Consultar => new Command(async () =>
		{
			await QueryWithSafety(async () => {

				var query = new ConsultaQuery();
				var result = await _queryExecutor.ExecuteAsync<ConsultaQuery, IEnumerable<ConsultaDto>>(query);

				foreach (var item in result)
				{
					Pessoas.Add(item);
				}

			});

		});

	}
}

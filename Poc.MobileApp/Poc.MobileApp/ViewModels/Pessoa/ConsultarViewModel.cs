using Poc.MobileApp.Domain;
using Poc.MobileApp.Domain.Queries;
using Poc.MobileApp.Domain.Queries.Pessoa;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
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

		public ICommand Consultar => new Command(async () =>
		{
			try
			{
				var query = new ConsultaQuery();
				var result = await _queryExecutor.ExecuteAsync<ConsultaQuery, IEnumerable<ConsultaDto>>(query);

				foreach (var item in result)
				{
					Pessoas.Add(item);
				}

			}
			catch (Exception e)
			{
				await App.Current.MainPage.DisplayAlert("Ocorreu um erro", e.Message, "Ok");
			}
		});

	}
}

using Poc.MobileApp.Domain;
using Poc.MobileApp.Domain.Commands;
using Poc.MobileApp.Domain.Queries;
using Poc.MobileApp.Domain.Queries.Pessoa;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Poc.MobileApp.ViewModels.Pessoa
{
	public partial class ConsultarViewModel : ViewModel
	{
		private readonly IQueryExecutor _queryExecutor;

		public Command Consultar { get; set; }

		public ObservableCollection<ConsultaDto> Pessoas { get; set; } = new ObservableCollection<ConsultaDto>();
		

		public ConsultarViewModel(IQueryExecutor queryExecutor)
		{
			Consultar = new Command(ConsultarAction);
			_queryExecutor = queryExecutor;
		}

		private async void ConsultarAction(object obj)
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
		}

	}
}

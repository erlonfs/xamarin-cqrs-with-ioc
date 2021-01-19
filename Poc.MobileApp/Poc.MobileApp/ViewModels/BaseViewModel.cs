using Poc.MobileApp.Shared.Common;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Poc.MobileApp.ViewModels
{
	public abstract class BaseViewModel : IViewModelBase
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyname = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
		}

		public async Task QueryWithSafety(Func<Task> action)
		{
			try
			{
				await action();
			}
			catch (BusinessException e)
			{
				await App.Current.MainPage.DisplayAlert("Verifique", e.Message, "Ok");
			}
			catch (Exception e)
			{
				await App.Current.MainPage.DisplayAlert("Ocorreu um erro", e.Message, "Ok");
			}
		}

		public async Task ExecuteWithSafety(Func<Task> action, Func<Task> afterSucessAction = null)
		{
			await ExecuteWithSafety(action, null , afterSucessAction);
		}

		public async Task ExecuteWithSafety(Func<Task> action, string messageSucess = null, Func<Task> afterSucessAction = null)
		{
			try
			{
				await action();

				await App.Current.MainPage.DisplayAlert("Sucesso", string.IsNullOrWhiteSpace(messageSucess) ? "Operação realizada com sucesso" : messageSucess, "Ok");

				if (afterSucessAction != null)
				{
					await afterSucessAction();
				}

			}
			catch (BusinessException e)
			{
				await App.Current.MainPage.DisplayAlert("Verifique", e.Message, "Ok");
			}
			catch (Exception e)
			{
				await App.Current.MainPage.DisplayAlert("Ocorreu um erro", e.Message, "Ok");
			}
		}
	}


}

﻿using CommonServiceLocator;
using Poc.MobileApp.ViewModels.Pessoa;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Poc.MobileApp.Views.Pessoa
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Consultar : ContentPage
	{
		public Consultar()
		{
			InitializeComponent();

			var viewModel = ServiceLocator.Current.GetInstance<ConsultarViewModel>();

			BindingContext = viewModel;
		}
	}
}
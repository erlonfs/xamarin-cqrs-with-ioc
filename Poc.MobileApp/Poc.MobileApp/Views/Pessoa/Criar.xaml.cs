using CommonServiceLocator;
using Poc.MobileApp.ViewModels.Pessoa;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Poc.MobileApp.Views.Pessoa
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Criar : ContentPage
	{
		public Criar()
		{
			InitializeComponent();

			var viewModel = ServiceLocator.Current.GetInstance<CriarViewModel>();

			BindingContext = viewModel;
		}
	}
}
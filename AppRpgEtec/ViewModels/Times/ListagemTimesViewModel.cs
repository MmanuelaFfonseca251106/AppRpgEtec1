using System.Collections.ObjectModel;
using System.Windows.Input;
using AppRpgEtec.Models;

namespace AppRpgEtec.ViewModels.Times
{
    public class ListagemTimesViewModel : BaseViewModel
    {
        private TimesService pService;
        public ObservableCollection<Time> Times { get; set; }
        public ICommand NovoTime { get; }

        public ListagemTimesViewModel()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty); // Usando Xamarin.Essentials para obter o token do usuário
            pService = new TimesService(token);
            Times = new ObservableCollection<Time>();
            _ = ObterTime();
            NovoTime = new Command(async () => { await ExibirCadastroTimes(); });
        }

        private Task ExibirCadastroTime()
        {
            throw new NotImplementedException();
        }

        public async Task ObterTime()
        {
            try
            {
                var times = await pService.GetTimesAsync();
                Times.Clear();  // Limpa a coleção antes de adicionar novos itens
                foreach (var time in times)
                {
                    Times.Add(time);
                }
                OnPropertyChanged(nameof(Times));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task ExibirCadastroTimes()
        {
            try
            {
                await Shell.Current.GoToAsync("cadTimeView"); // Navegação para a página de cadastro
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }
    }
}

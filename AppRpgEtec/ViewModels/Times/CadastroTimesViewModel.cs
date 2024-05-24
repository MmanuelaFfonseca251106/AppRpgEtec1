using AppRpgEtec.Services.Times;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AppRpgEtec.Models;
using System.Windows.Input;

namespace AppRpgEtec.ViewModels.Times
{
    public class CadastroTimesViewModel : BaseViewModel
    {
        private TimesService pService;
        public ICommand SalvarCommand { get; set; }
        public ICommand AdicionarAoTimeCommand { get; set; }

        public CadastroTimesViewModel()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            pService = new TimesService(token);
            SalvarCommand = new Command(async () => { await SalvarTime(); });
            AdicionarAoTimeCommand = new Command(AdicionarAoTime);
            _ = ObterClasses();
        }

        private async Task SalvarTime()
        {
            throw new NotImplementedException();
        }

        private int id;
        private string nome;
        private int nível;
        private int raça;
        private string classe1;

        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string Nome
        {
            get => nome;
            set
            {
                nome = value;
                OnPropertyChanged(nameof(Nome));
            }
        }
        public int Nível
        {
            get => nível;
            set
            {
                nível = value;
                OnPropertyChanged(nameof(Nível));
            }
        }
        public int Raça
        {
            get => raça;
            set
            {
                raça = value;
                OnPropertyChanged(nameof(Raça));
            }
        }
        public string Classe1
        {
            get => classe1;
            set
            {
                classe1 = value;
                OnPropertyChanged(nameof(Classe1));
            }
        }

        private ObservableCollection<TipoClasse> listaTiposClasse;
        public ObservableCollection<TipoClasse> ListaTiposClasse
        {
            get => listaTiposClasse;
            set
            {
                listaTiposClasse = value;
                OnPropertyChanged(nameof(ListaTiposClasse));
            }
        }

        private ObservableCollection<TipoClasse> listaTime;
        public ObservableCollection<TipoClasse> ListaTime
        {
            get => listaTime;
            set
            {
                listaTime = value;
                OnPropertyChanged(nameof(ListaTime));
            }
        }

        private TipoClasse tipoClasseSelecionado;
        public TipoClasse TipoClasseSelecionado
        {
            get => tipoClasseSelecionado;
            set
            {
                tipoClasseSelecionado = value;
                OnPropertyChanged(nameof(TipoClasseSelecionado));
            }
        }

        public async Task ObterClasses()
        {
            try
            {
                ListaTiposClasse = new ObservableCollection<TipoClasse>
                {
                    new TipoClasse { Id = 1, Nome = "Julia", Nível = 3, Raça = "Elfo", Classe1 = "Clerigo" },
                    new TipoClasse { Id = 2, Nome = "Marcelo", Nível = 4, Raça = "Anão", Classe1 = "Mago" },
                    new TipoClasse { Id = 3, Nome = "Madalena", Nível = 7, Raça = "Humano", Classe1 = "Guerreiro" }
                };
                ListaTime = new ObservableCollection<TipoClasse>();
                OnPropertyChanged(nameof(ListaTiposClasse));
                OnPropertyChanged(nameof(ListaTime));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + " Detalhes:" + ex.InnerException, "OK");
            }
        }

        private void AdicionarAoTime()
        {
            if (ListaTime.Count >= 5)
            {
                Application.Current.MainPage.DisplayAlert("Limite de Time", "Já existem 5 aventureiros na sua equipe!", "OK");
                return;
            }

            if (TipoClasseSelecionado != null && !ListaTime.Contains(TipoClasseSelecionado))
            {
                ListaTime.Add(TipoClasseSelecionado);
                ListaTiposClasse.Remove(TipoClasseSelecionado);
                OnPropertyChanged(nameof(ListaTime));
                OnPropertyChanged(nameof(ListaTiposClasse));
            }
        }
    }
}

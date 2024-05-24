using AppRpgEtec.Services.Personagens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppRpgEtec.Models;
using AppRpgEtec.Models.Enuns;
using System.Windows.Input;
using System.Security.AccessControl;


namespace AppRpgEtec.ViewModels.Personagens
{
    public class CadastroPersonagemViewModel : BaseViewModel
    {
        private PersonagemService pService;
        public ICommand SalvarCommand { get; set; }

        public CadastroPersonagemViewModel()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            pService = new PersonagemService(token);
            _ = ObterClasses();
            SalvarCommand = new Command(async () => { await SalvarPersonagem(); });
        }
        private int id;
        private string nome;
        private int nível;
        private int raça;
        private string classe1;

        public int Id
        {
            get => Id;
            set
            {
                Id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
            public string Nome
        {
            get => Nome;
            set
            {
                Nome = value;
                OnPropertyChanged(nameof(Nome));
            }
        }
           public int Nível
        {
            get => Nível;
            set
            {
                Nível = value;
                OnPropertyChanged(nameof(Nível));
            }
         }
        public int Raça
        {
            get => Raça;
            set
            {
               Raça = value;
                OnPropertyChanged(nameof(Raça));
            }
        }
        public string Classe1
        {
            get => Classe1;
            set
            {
                Classe1 = value;
                OnPropertyChanged(nameof(Classe1));
            }
        }
        private ObservableCollection<TipoClasse> listaTiposClasse;

        public ObservableCollection<TipoClasse> ListaTiposClasse
        {
            get { return listaTiposClasse; }
            set
            {
                if (value == null)
                {
                    listaTiposClasse = value;
                    OnPropertyChanged(nameof(ListaTiposClasse));
                }
            }
        }

        public async Task ObterClasses()
        {
            try
            {
                ListaTiposClasse = new ObservableCollection<TipoClasse>();
                ListaTiposClasse.Add(new TipoClasse { Id = 1, Nome = "Julia",Nível= 3,Raça= "Elfo",Classe1="Clerigo" });
                ListaTiposClasse.Add(new TipoClasse { Id = 2, Nome = "Marcelo", Nível = 4, Raça = "Anão",Classe1="Mago"});
                ListaTiposClasse.Add(new TipoClasse { Id = 3, Nome = " Madalena", Nível = 7, Raça = "Humano",Classe1="Guerreiro"});
                OnPropertyChanged(nameof(ListaTiposClasse));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + "Detalhes:" + ex.InnerException, "OK");
            }
        }
        private TipoClasse tipoClasseSelecionado;

        public TipoClasse TipoClasseSelecionado
        {
            get { return tipoClasseSelecionado; }
            set
            {
                if (value != null)
                {
                    tipoClasseSelecionado = value;
                    OnPropertyChanged(nameof(TipoClasseSelecionado));

                }
            }
        }
        public async Task SalvarPersonagem()
        {
            try
            {
                Personagem model = new Personagem()
                {
                    Nome = this.nome,
                    Nível = this.nível,
                    Raça = this.raça,
                    Classe1 = this.classe1,

                    Id = this.id,
                    Classe = (ClasseEnum)tipoClasseSelecionado.Id

                };
                if (model.Id == 0)
                    await pService.PostPersonagemAsync(model);

                await Application.Current.MainPage
                    .DisplayAlert("Mensagem", "Dados salvos com sucesso!", "OK");

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex) 
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + "Detalhes:" + ex.InnerException, "OK");
            }

            }
       }
    }


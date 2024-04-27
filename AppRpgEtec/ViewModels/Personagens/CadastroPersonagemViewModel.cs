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


namespace AppRpgEtec.ViewModels.Personagens
{
    public class CadastroPersonagemViewModel : BaseViewModel
    {
        private PersonagemService pService;
        public ICommand SalvarCommand { get; }

        public CadastroPersonagemViewModel()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            pService = new PersonagemService(token);
            _ = ObterClasses();
            SalvarCommand = new Command(async () => { await SalvarPersonagem(); });
        }
        private int id;
        private string nome;
        private int pontosVida;
        private int forca;
        private int defesa;
        private int inteligencia;
        private int disputas;
        private int vitorias;
        private int derrotas;

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
           public int PontosVida
        {
            get => PontosVida;
            set
            {
                PontosVida = value;
                OnPropertyChanged(nameof(PontosVida));
            }
         }
         public int Forca
        {
            get => Forca;
            set
            {
                Forca = value;
                OnPropertyChanged(nameof(Forca));
            }
        }
          public int Defesa
        {
            get => Defesa;
            set
            {
                Defesa = value;
                OnPropertyChanged(nameof(Defesa));
            }
        }
          public int Inteligencia
        {
            get => Inteligencia;
            set
            {
                Inteligencia = value;
                OnPropertyChanged(nameof(Inteligencia));
            }
         }
         public int Disputas
        {
            get => Disputas;
            set
            {
                Disputas = value;
                OnPropertyChanged(nameof(Disputas));
            }
        }
        public int Vitorias
        {
            get => Vitorias;
            set
            {
                Vitorias = value;
                OnPropertyChanged(nameof(Vitorias));
            }
        }
         public int Derrotas
        {
            get => Derrotas;
            set
            {
                Derrotas = value;
                OnPropertyChanged(nameof(Derrotas));
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
                ListaTiposClasse.Add(new TipoClasse { Id = 1, Descricao = "Cavaleiro" });
                ListaTiposClasse.Add(new TipoClasse { Id = 2, Descricao = "Mago" });
                ListaTiposClasse.Add(new TipoClasse { Id = 3, Descricao = " Clerigo" });
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
                    PontosVida = this.pontosVida,
                    Defesa = this.defesa,
                    Derrotas = this.derrotas,
                    Forca = this.forca,
                    Inteligencia = this.inteligencia,
                    Vitorias = this.vitorias,
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


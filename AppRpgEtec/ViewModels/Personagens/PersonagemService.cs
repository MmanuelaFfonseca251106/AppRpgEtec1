using AppRpgEtec.Models;
using System.Collections.ObjectModel;

namespace AppRpgEtec.ViewModels.Personagens
{
    internal class PersonagemService
    {
        private string token;

        public PersonagemService(string token)
        {
            this.token = token;
        }

        internal Task<ObservableCollection<Personagem>> GetPersonagensAsync()
        {
            throw new NotImplementedException();
        }

        internal Task PostPersonagemAsync(Personagem model)
        {
            throw new NotImplementedException();
        }
    }
}
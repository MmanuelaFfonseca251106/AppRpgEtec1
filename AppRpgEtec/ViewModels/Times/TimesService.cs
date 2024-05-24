using AppRpgEtec.Models;


namespace AppRpgEtec.ViewModels.Times
{
    internal class TimesService
    {
        private string token;

        public TimesService(string token)
        {
            this.token = token;
        }

        internal Task<System.Collections.ObjectModel.ObservableCollection<Time>> GetTimesAsync()
        {
            throw new NotImplementedException();
        }

        internal Task PostTimesAsync(Time model)
        {
            throw new NotImplementedException();
        }

       
    }
}
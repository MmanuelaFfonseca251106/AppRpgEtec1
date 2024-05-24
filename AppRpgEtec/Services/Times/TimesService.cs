
using AppRpgEtec.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppRpgEtec.Services.Times
{
    public class TimesService : Request
    {
        private readonly Request _request;
        private const string _apiUrlBse = "https://rpgapi20241pam.azurewebsites.net/Times";

        private string _token;
        private string timesId;

        public TimesService(string token)
        {
            _request = new Request();
            _token = token;
        }
        public async Task<Time> PostTimesAsync(Time t)
        {
            return await _request.PostAsync(_apiUrlBse, t, _token);
        }

        public async Task<ObservableCollection<Time>> GetTimesAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");
            ObservableCollection<Models.Time> listaTimes = await
      _request.GetAsync<ObservableCollection<Models.Time>>(_apiUrlBse + urlComplementar, _token);
            return listaTimes;
        }

        public async Task<Time> GetTimesAsync(int timesId)
        {
            string urlComplementar = string.Format("/{0}", timesId);
            var times = await _request.GetAsync<Models.Time>(_apiUrlBse + urlComplementar, _token);
            return times;
        }

        public async Task<int> PutTimesAsync(Time t)
        {
            var result = await _request.PutAsync(_apiUrlBse, t, _token);
            return result;
        }

        public async Task<int> DeleteTimesAsync(int TimesId)
        {
            string urlComplementar = string.Format("/{0}", timesId);
            var result = await _request.DeleteAsync(_apiUrlBse + urlComplementar, _token);
            return result;
        }



    }

}



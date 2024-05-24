using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRpgEtec.ViewModels.Dado
{
    public class Dado : BaseViewModel
    {
        public Dado()
        {

        }

        private int total = 0;

        public int Total
        {
            get => total;
            set
            {
                total = value;
                OnPropertyChanged(nameof(Total));
            }

        }

        private Random random = new Random();

        public int QuantidadeDados { get; set; }
        public int QuantidadeLados { get; set; }

        public Dado(int quantidadeDados, int quantidadeLados)
        {
            QuantidadeDados = quantidadeDados;
            QuantidadeLados = quantidadeLados;
        }

        public void RolarDados()
        {
            int totalInterno = 0;
            for (int i = 0; i < QuantidadeDados; i++)
            {
                totalInterno += random.Next(1, QuantidadeLados + 1);
            }

            Total = totalInterno;


        }
    }
}


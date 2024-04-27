using System;

namespace AppRpgEtec.Models
{
    public class Dado
    {
        private Random random = new Random();

        public int QuantidadeDados { get; set; }
        public int QuantidadeLados { get; set; }

        public Dado(int quantidadeDados, int quantidadeLados)
        {
            QuantidadeDados = quantidadeDados;
            QuantidadeLados = quantidadeLados;
        }

        public int RolarDados()
        {
            int total = 0;
            for (int i = 0; i < QuantidadeDados; i++)
            {
                total += random.Next(1, QuantidadeLados + 1);
            }
            return total;
        }
    }
}

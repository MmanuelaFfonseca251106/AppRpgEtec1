using AppRpgEtec.Models.Enuns;

namespace AppRpgEtec.Models
{
   public class Personagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public  byte[] FotoPersonagem { get; set; }
        public  ClasseEnum Classe { get; set; }
        public int Nível { get; internal set; }
        public int Raça { get; internal set; }
        public string Classe1 { get; internal set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRpgEtec.Models
{
    public class TipoClasse
    {
        public int Id { get; set; }
        public string Raça { get; set; }
        public object Nome { get; internal set; }
        public int Nível { get; set; }
        public string Classe1 { get; set; }
    }
}

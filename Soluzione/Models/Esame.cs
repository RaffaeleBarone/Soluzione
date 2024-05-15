using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto1.Models
{
    public class Esame
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Voto {  get; set; }
        public Studente Studente { get; set; }
    }
}

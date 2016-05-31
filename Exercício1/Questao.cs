using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC
{
    class Questao
    {
        public int Codigo { get; set; }
        public string Enunciado { get; set; }
        public List<string> Alternativas { get; set; }
        public char Resposta { get; set; }
        public int Dificuldade { get; set; }

    }
}

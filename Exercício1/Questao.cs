using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC
{
    public class Questao
    {
        public int Codigo { get; set; }
        public string Enunciado { get; set; }
        public List<string> Alternativas { get; set; }
        public char Resposta { get; set; }
        public int Dificuldade { get; set; }

        public override string ToString()
        {
            string Alter = null;
            foreach (string t in Alternativas)
            {
                Alter = Alter + t + "\n";
            }
            return "Codigo: " + Codigo + "\n" +
            "Enunciado: " + Enunciado + "\n" +
            "Alternativas: " + Alter + "\n" +
            "Resposta: " + Resposta + "\n" +
            "Dificuldade: " + Dificuldade + "\n";
        }

    }
}

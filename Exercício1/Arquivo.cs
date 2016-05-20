using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercício1
{
    class Arquivo
    {
        public static void Leitura(List<Questao> lista){
            StreamReader sr;
            string linha;

            if (File.Exists("arquivo.txt"))
            {
                try
                {
                    using (sr = new StreamReader("arquivo.txt"))
                    {
                        while ((linha = sr.ReadLine()) != null)
                        {
                            Questao x = new Questao();
                            string[] aux = linha.Split('|');
                            x.Codigo = int.Parse(aux[0]);
                            x.Enunciado = aux[1];
                            x.Alternativas.Add(aux[2]);
                            x.Resposta = char.Parse(aux[3]);
                            x.Dificuldade = int.Parse(aux[4]);
                            lista.Add(x);
                        }
                        sr.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
                Console.WriteLine("Arquivo não localizado");
        }
        public static void Gravacao(List<Questao> lista)
        {
            StreamWriter sw;
            try
            {
                using (sw = new StreamWriter("arquivo.txt"))
                {
                    foreach (Questao item in lista)
                    {
                        sw.WriteLine(item.Codigo + "|" + item.Enunciado + "|" + item.Alternativas + "|" + item.Resposta + "|" + item.Dificuldade);
                    }
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}

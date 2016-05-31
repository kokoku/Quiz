using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC
{
    class Arquivo
    {
        //LENDO ARQUIVO DE QUESTÕES
        public static void Leitura_Questao(List<Questao> lista)
        {
            StreamReader sr;
            string linha;

            if (File.Exists("Arquivo.txt"))
            {
                try
                {
                    using (sr = new StreamReader("Arquivo.txt"))
                    {
                        while ((linha = sr.ReadLine()) != null)
                        {
                            Questao x = new Questao();
                            string[] aux = linha.Split('|');
                            x.Codigo = int.Parse(aux[0]);
                            x.Enunciado = aux[1];
                            x.Resposta = char.Parse(aux[6]);
                            x.Dificuldade = int.Parse(aux[7]);
                            x.Alternativas = new List<string>();
                            x.Alternativas.Add(aux[2]);
                            x.Alternativas.Add(aux[3]);
                            x.Alternativas.Add(aux[4]);
                            x.Alternativas.Add(aux[5]);

                            lista.Add(x);
                        }
                        sr.Close();
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                }
            }
            else
                Console.WriteLine("Arquivo não localizado");
        }

        //LENDO ARQUIVO DE JOGADORES
        public static void Leitura_Jogador(List<Jogador> lista)
        {
            StreamReader sr;
            string linha;

            if (File.Exists("Usuarios.txt"))
            {
                try
                {
                    using (sr = new StreamReader("Usuarios.txt"))
                    {
                        while ((linha = sr.ReadLine()) != null)
                        {
                            Jogador x = new Jogador();
                            string[] aux = linha.Split('|');
                            x.Nome = aux[0];
                            x.Pontos = int.Parse(aux[1]);
                            x.PerguntasRespondidas.Add(int.Parse(aux[2]));
                            lista.Add(x);
                        }
                        sr.Close();
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                }
            }
            else
                Console.WriteLine("Arquivo não localizado");
        }

        //GRAVANDO NO ARQUIVO DE JOGADORES
        public static void Gravacao_Usuario(List<Jogador> lista_jogadores)
        {
            StreamWriter sw;

            using (sw = new StreamWriter("Usuarios.txt"))
            {
                foreach (Jogador item in lista_jogadores)
                {
                    sw.Write(item.Nome + "|" + item.Pontos + "|");
                    for (int i = 0; i < item.PerguntasRespondidas.Count; i++)
                    {
                        sw.Write(item.PerguntasRespondidas[i] + "|");
                    }
                }
                sw.Close();
            }
        }



    }
}

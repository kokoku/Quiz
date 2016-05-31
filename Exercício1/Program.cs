using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC
{
    class Program
    {
        static void Main(string[] args)
        {
            			List<Questao> lista = new List<Questao>();
            Arquivo.Leitura_Questao(lista);

            List<Jogador> lista_jogadores = new List<Jogador>();
            Arquivo.Leitura_Jogador(lista_jogadores);

            Jogador novo_jogador;
            int op, nivel;

            //1º MENU
            do
            {
                op = Menu1();
                switch (op)
                {
                    case 1:
                        //Cadastro de novo jogador
                        novo_jogador = new Jogador();
                        novo_jogador = Cadastro();
                        Arquivo.Leitura_Jogador(lista_jogadores);
                        lista_jogadores.Add(novo_jogador);
                        Arquivo.Gravacao_Usuario(lista_jogadores);
                        op = 0;
                        Console.Clear();
                        break;
                }
            } while (op != 0);
            //2º MENU
            do
            {
                op = Menu2();
                switch (op)
                {
                    case 1:
                        //Informações sobre o Jogador
                        Console.Clear();
                        Arquivo.Leitura_Jogador(lista_jogadores);
                        foreach (Jogador item in lista_jogadores)
                        {
                            Console.Write("Nome: " + item.Nome + "\n");
                            Console.Write("Pontos: " + item.Pontos + "\n");
                            Console.Write("Perguntas respondidas: ");
                            for (int i = 0; i < item.PerguntasRespondidas.Count; i++)
                            {
                                Console.Write(item.PerguntasRespondidas[i] + ", ");
                            }
                            Console.WriteLine("");
                        }
                        break;
                    case 2:
                        //QUIZ
                        Jogador x = new Jogador();
                        Arquivo.Leitura_Jogador(lista_jogadores);
                        foreach (Jogador item in lista_jogadores)
                        {
                            x.Nome = item.Nome;
                            x.Pontos = item.Pontos;
                            x.PerguntasRespondidas = new List<int>();
                            for (int i = 0; i < item.PerguntasRespondidas.Count; i++)
                            {
                                x.PerguntasRespondidas.Add(item.PerguntasRespondidas[i]);
                            }
                        }
                        lista_jogadores = new List<Jogador>();
                        Console.Clear();
                        Console.WriteLine("Qual o nível de dificuldade das perguntas que deseja responder?(1,2 ou3)");
                        nivel = int.Parse(Console.ReadLine());
                        Jogar(nivel, lista, lista_jogadores, x);
                        lista_jogadores.Add(x);
                        Arquivo.Gravacao_Usuario(lista_jogadores);
                        break;
                }
            } while (op != 0);
        }

        //LÓGICA DO QUIZ
        public static void Jogar(int nivel, List<Questao> lista, List<Jogador>lista_jogadores, Jogador jogador)
        {
            char resposta;
            lista_jogadores = new List<Jogador>();
            foreach (Questao item in lista)
            {
                if(item.Dificuldade == nivel)
                {
                    Console.WriteLine("--------------------------------------------------------------------------------");
                    Console.WriteLine(item.Enunciado);
                    for (int i = 0; i < item.Alternativas.Count; i++)
                    {
                        Console.Write(item.Alternativas[i] + "\n");
                    }
                    Console.WriteLine("");
                    Console.WriteLine("--------------------------------------------------------------------------------");
                    Console.WriteLine("Qual a alternativa correta? ");
                    resposta = char.Parse(Console.ReadLine());
                    if (resposta == item.Resposta)
                    {
                        Console.WriteLine("==================");
                        Console.WriteLine("   Você Acertou!");
                        Console.WriteLine("==================\n");
                        Console.WriteLine("\n");
                        Console.WriteLine("\n");
                        Console.Write("Pressione qualquer tecla para continuar");
                        jogador.Pontos += 1;
                        jogador.PerguntasRespondidas.Add(item.Codigo);
                    }
                    else
                    {
                        Console.WriteLine("=================================================");
                        Console.WriteLine("   Você errou, o correto era " + item.Resposta);
                        Console.WriteLine("=================================================\n");
                        Console.WriteLine("\n");
                        Console.WriteLine("\n");
                        Console.Write("Pressione qualquer tecla para continuar");
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        //CADASTRO DO JOGADOR
        public static Jogador Cadastro()
        {
            Jogador x = new Jogador();
            Console.Write("Insira o nome: ");
            x.Nome = Console.ReadLine();
            x.Pontos = 0;
            x.PerguntasRespondidas = new List<int>();
            return x;
        }

        //MENU DE CADASTRO
        public static int Menu1()
        {
            int opcao;
            do{
                Console.WriteLine("             ========================MENU====================");
                Console.WriteLine("             | 0 - Sair                                     |");
                Console.WriteLine("             | 1 - Cadastro                                 |");
                Console.WriteLine("             ================================================");
                opcao = int.Parse(Console.ReadLine());
            }while(opcao<0 || opcao > 1);
            if (opcao == 0)
                Environment.Exit(0);
            return opcao;
        }

        //MENU DE OPÇÕES DO JOGO
        public static int Menu2()
        {
            int opcao;
            do
            {
                Console.WriteLine("             ========================MENU====================");
                Console.WriteLine("             | 0 - Sair                                     |");
                Console.WriteLine("             | 1 - Informações sobre o Jogador              |");
                Console.WriteLine("             | 2 - Jogar                                    |");
                Console.WriteLine("             ================================================");
                opcao = int.Parse(Console.ReadLine());
            } while (opcao < 0 || opcao > 2);
            return opcao;

        }
    }
}

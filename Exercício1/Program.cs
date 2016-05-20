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
            Questao novo;
            Jogador novo_jogador;
            List<Jogador> lista_jogadores = new List<Jogador>();
            Arquivo.Leitura_Jogador(lista_jogadores);
            int op;
            //1º MENU
            do
            {
                op = Menu1();
                switch (op)
                {
                    case 1:
                        novo_jogador = new Jogador();
                        novo_jogador = Cadastro();
                        //Arquivo.Leitura_Jogador(lista_jogadores);
                        foreach (Jogador item in lista_jogadores)
                        {
                            if (item.Nome == novo_jogador.Nome)

                                Console.WriteLine("Usuário já existe");
                            else
                            {
                                lista_jogadores.Add(novo_jogador);
                                Arquivo.Gravacao_Usuario(lista_jogadores);
                                op = 0;
                            }

                        }
                        break;
                    case 2:
                        if (Login(lista_jogadores) == true)
                            Console.WriteLine("Login efetuado com sucesso");
                        else
                            Console.WriteLine("Usuário não encontrado");
                        op = 0;
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
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
            } while (op != 0);

            Arquivo.Gravacao_Questao(lista);
        }

        public static bool Login(List<Jogador> lista_jogadores)
        {
            Arquivo.Leitura_Jogador(lista_jogadores);
            Console.WriteLine("Qual o nome do seu usuario: ");
            string nome = Console.ReadLine();
            foreach (Jogador item in lista_jogadores)
            {
                if (item.Nome == nome)
                    return true;
            }
            return false;
        }

        public static Jogador Cadastro()
        {
            Jogador x = new Jogador();
            Console.Write("Insira o nome ");
            x.Nome = Console.ReadLine();
            x.Pontos = 0;
            x.PerguntasRespondidas = null;
            return x;
        }

        public static int Menu1()
        {
            int opcao;
            do
            {
                Console.WriteLine("             ========================MENU====================");
                Console.WriteLine("             | 0 - Sair                                     |");
                Console.WriteLine("             | 1 - Cadastro                                 |");
                Console.WriteLine("             | 2 - Login                                    |");
                Console.WriteLine("             ================================================");
                opcao = int.Parse(Console.ReadLine());
            } while (opcao < 0 || opcao > 2);
            return opcao;
        }
        public static int Menu2()
        {
            int opcao;
            do
            {
                Console.WriteLine("             ========================MENU====================");
                Console.WriteLine("             | 0 - Sair                                     |");
                Console.WriteLine("             | 1 - Pontuação                                |");
                Console.WriteLine("             | 2 - Perguntas já respondidas                 |");
                Console.WriteLine("             | 3 - Jogar                                    |");
                Console.WriteLine("             ================================================");
                opcao = int.Parse(Console.ReadLine());
            } while (opcao < 0 || opcao > 2);
            return opcao;
        }

    }
}

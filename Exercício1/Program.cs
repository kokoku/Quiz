using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercício1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Questao> lista = new List<Questao>();
            Arquivo.Leitura(lista);
            Questao novo;
            int op;
            do
            {
                op = Menu();
                switch (op)
                {
                    case 1:

                        break;
                    case 2:
                        
                        break;
                    case 3:
                        
                        break;
                    case 4:
                        Imprimir(lista);
                        break;
                }
            } while (op != 0);
            Arquivo.Gravacao(lista);
        }

        private static void Imprimir(List<Questao> lista)
        {
            foreach (var item in lista)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static int Menu()
        {
            int opcao;
            do{
                Console.WriteLine("             ========================MENU====================");
                Console.WriteLine("             | 0 - Sair                                     |");
                Console.WriteLine("             | 1 - Inserir                                  |");
                Console.WriteLine("             | 2 - Remover                                  |");
                Console.WriteLine("             | 3 - Alterar                                  |");
                Console.WriteLine("             | 4 - Imprimir                                 |");
                Console.WriteLine("             ================================================");
                opcao = int.Parse(Console.ReadLine());
            }while(opcao<0 || opcao > 4);
            return opcao;
        }
        }
    }
}

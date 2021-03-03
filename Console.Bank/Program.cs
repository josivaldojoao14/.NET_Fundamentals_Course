using Console.Bank.Classes;
using Console.Bank.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Console.Bank
{
    class Program
    {
        static readonly List<Conta> ListContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUser = UserOptions();

            while (opcaoUser.ToUpper() != "X")
            {
                switch (opcaoUser)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        AbrirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        System.Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUser = UserOptions();
            }           
        }

        private static void Depositar()
        {
            System.Console.Write("Digite o número da conta: ");
            int idConta = int.Parse(System.Console.ReadLine());

            System.Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(System.Console.ReadLine());

            ListContas[idConta].Depositar(valorDeposito);
        }

        private static void Transferir()
        {
            System.Console.Write("Digite o número da conta de origem: ");
            int idContaOrigem = int.Parse(System.Console.ReadLine());

            System.Console.Write("Digite o número da conta de destino: ");
            int idContaDestino = int.Parse(System.Console.ReadLine());

            System.Console.Write("Digite o valor a transferir: ");
            double valorTed = double.Parse(System.Console.ReadLine());

            ListContas[idContaOrigem].Transferir(valorTed, ListContas[idContaDestino]);
        }

        private static void Sacar()
        {
            System.Console.Write("Digite o número da conta: ");
            int idConta = int.Parse(System.Console.ReadLine());

            System.Console.Write("Digite o valor a sacar: ");
            double valorSaque = double.Parse(System.Console.ReadLine());

            ListContas[idConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            System.Console.WriteLine("Listando as contas...");

            if (ListContas.Count() == 0)
            {
                System.Console.WriteLine("Ainda não existem clientes registrados.");
                return;
            }

            for (int i = 0; i < ListContas.Count(); i++)
            {
                Conta conta = ListContas[i];
                System.Console.Write("#{0} - ", i);
                System.Console.WriteLine(conta);
            }
        }

        private static void AbrirConta()
        {
            System.Console.WriteLine("Qual tipo de conta deseja abrir?");
            System.Console.WriteLine("Digite:\n 1 - Jurídica  \n  2 - Física");

            int EntradaConta = int.Parse(System.Console.ReadLine());
            System.Console.WriteLine();

            System.Console.Write("Digite o nome do cliente: ");
            string EntradaNome = System.Console.ReadLine();

            System.Console.Write("Digite seu saldo inicial: ");
            double EntradaSaldo = double.Parse(System.Console.ReadLine());

            System.Console.Write("Digite seu crédito inicial: ");
            double EntradaCredito = double.Parse(System.Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)EntradaConta,
                                        saldo: EntradaSaldo,
                                        credito: EntradaCredito,
                                        nome: EntradaNome);
            ListContas.Add(novaConta);
        }

        private static string UserOptions()
        {
            System.Console.WriteLine("Informe a opção desejada:\n");
            System.Console.WriteLine("1 - Listar contas");
            System.Console.WriteLine("2 - Abrir nova conta");
            System.Console.WriteLine("3 - Transferir");
            System.Console.WriteLine("4 - Sacar");
            System.Console.WriteLine("5 - Depositar");
            System.Console.WriteLine("C - Limpar tela");
            System.Console.WriteLine("X - Encerrar");
            System.Console.WriteLine();

            string opcaoUser = System.Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUser;
        }

    }
}

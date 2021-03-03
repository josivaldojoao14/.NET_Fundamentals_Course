using Console.Bank.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console.Bank.Classes
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }

        private double Saldo { get; set; }

        private double Credito { get; set; }

        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito*-1))
            {
                System.Console.WriteLine("Saldo insuficiente");
                return false;
            }

            this.Saldo -= valorSaque;
            System.Console.WriteLine("Olá, {0}.\n Seu saldo é: {1}", this.Nome, this.Saldo);

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            System.Console.WriteLine("Olá, {0}. Seu saldo atual após o deposito é de: {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia)) 
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public string Detalhes()
        {
            string retorno = " ";
            retorno += "Tipo da conta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito + " | ";
            return retorno;
        }

    }
}

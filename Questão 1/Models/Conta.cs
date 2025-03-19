namespace ContaBancaria.Models;
class Conta
{
    public int NumeroConta { get; protected set; }
    public string Titular { get; protected set; }
    public double Saldo { get; protected set; }

    public Conta(int numeroConta, string titular)
    {
        SetNumeroConta(numeroConta);
        SetTitular(titular);
        SetSaldo(1000);
    }

    public void SetNumeroConta(int numeroConta)
    {
        if (numeroConta < 0)
        {
            throw new Exception("Número da conta inválido");
        }
        NumeroConta = numeroConta;
    }
    public void SetTitular(string titular)
    {
        if (string.IsNullOrWhiteSpace(titular) && titular.Length > 255)
        {
            throw new Exception("Nome de titular inválido");
        }
        Titular = titular;
    }
    public void SetSaldo(double saldo)
    {
        if (saldo < 0)
        {
            throw new Exception("O saldo da conta é inválido");
        }
        Saldo = saldo;
    }

    public void Depositar(double deposito)
    {
        if (deposito < 0)
        {
            Console.WriteLine("Valor de depósito inválido");
        }
        else
        {
            Saldo += deposito;
        }
    }
    public void Sacar(double saque)
    {
        if (saque < 0)
        {
            Console.WriteLine("Valor de saque Inválido");
        }
        else
        {
            Saldo -= saque;
        }
    }
}
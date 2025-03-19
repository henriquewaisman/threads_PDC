using ContaBancaria.Models;
class Program
{
    static List<Conta> contas = new List<Conta>();
    static void Main(string[] args)
    {
        Conta c = new Conta(1, "Henrique");
        contas.Add(c);



    }

    static void AGastadora()
    {
        if (contas[0].Saldo >= 10)
        {
            contas[0].Sacar(10);
        }
        Thread.Sleep(3000);
    }

    // public void AEsperta()
    // {
    //     if (Saldo >= 50)
    //     {
    //         Saldo -= 50;
    //     }
    //     Thread.Sleep(6000);
    // }
    // public void AEconomica()
    // {
    //     if (Saldo >= 5)
    //     {
    //         Saldo -= 5;
    //     }
    //     Thread.Sleep(12000);
    // }
}

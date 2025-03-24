class Conta
{
    public int NumeroConta { get; private set; }
    public string Titular { get; private set; }
    public double Saldo { get; private set; }
    private readonly object _lock = new object();

    public Conta(int numeroConta, string titular)
    {
        if (numeroConta < 0) throw new ArgumentException("Número da conta inválido");
        if (string.IsNullOrWhiteSpace(titular) || titular.Length > 255) throw new ArgumentException("Nome de titular inválido");

        NumeroConta = numeroConta;
        Titular = titular;
        Saldo = 1000;
    }

    public bool Sacar(double valor, string threadName, ref int totalSaques, ref double totalRetirado)
    {
        lock (_lock)
        {
            while (Saldo < valor)
            {
                Console.WriteLine($"{threadName} está esperando... Saldo insuficiente!");
                Monitor.Wait(_lock);
            }

            Saldo -= valor;
            totalSaques++;
            totalRetirado += valor;

            Console.WriteLine($"{threadName} sacou R$ {valor}. Saldo restante: R$ {Saldo}");
            return true;
        }
    }
    public void Depositar(double valor)
    {
        lock (_lock)
        {
            Saldo += valor;
            Console.WriteLine($"APatrocinadora depositou R$ {valor}. Novo saldo: R$ {Saldo}");
            Monitor.PulseAll(_lock);
        }
    }

}
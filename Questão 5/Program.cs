using System;
using System.Threading;

class Semaforo
{
    private bool verde;
    private readonly object lockObj = new object(); // Objeto de bloqueio para sincronização

    public Semaforo()
    {
        this.verde = true;
    }

    public void MudarEstado()
    {
        lock (lockObj) //Impede concorrencia
        {
            verde = !verde;
            Console.WriteLine("Semáforo agora está " + (verde ? "VERDE" : "VERMELHO"));
        }
    }

    public bool PodePassar()
    {
        lock (lockObj)
        {
            return verde;
        }
    }
}

class Veiculo
{
    private string nome;
    private Semaforo semaforo;

    public Veiculo(string nome, Semaforo semaforo)
    {
        this.nome = nome;
        this.semaforo = semaforo;
    }

    public void Dirigir()
    {
        Console.WriteLine(nome + " se aproximando do cruzamento...");
        while (!semaforo.PodePassar())
        {
            Thread.Sleep(1000);
            Console.WriteLine(nome + " parou");
        }
        Console.WriteLine(nome + " cruzou com sucesso!");
    }
}

class SimulacaoTrafego
{
    static void Main()
    {
        Semaforo semaforo = new Semaforo();

        Thread carro1 = new Thread(() => new Veiculo("Carro 1", semaforo).Dirigir());
        Thread carro2 = new Thread(() => new Veiculo("Carro 2", semaforo).Dirigir());
        Thread carro3 = new Thread(() => new Veiculo("Carro 3", semaforo).Dirigir());
        Thread carro4 = new Thread(() => new Veiculo("Carro 4", semaforo).Dirigir());
        Thread carro5 = new Thread(() => new Veiculo("Carro 5", semaforo).Dirigir());

        carro1.Start();
        carro2.Start();
        carro3.Start();

        semaforo.MudarEstado();

        carro4.Start();

        semaforo.MudarEstado();

        carro5.Start();
    


        carro1.Join();
        carro2.Join();
        carro3.Join();
        carro4.Join();
        carro5.Join();

        Console.WriteLine("Simulação finalizada.");
    }
}